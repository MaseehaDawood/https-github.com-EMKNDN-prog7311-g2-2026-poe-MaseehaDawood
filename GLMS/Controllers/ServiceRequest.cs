using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GLMS.Data;
using GLMS.Models;
using GLMS.Services;

namespace GLMS.Controllers
{

    public class ServiceRequestController : Controller
    {
        private readonly AppDbContext _context;
        private readonly CurrencyService _currency;
        private readonly IPricingStrategy _pricing;

        public ServiceRequestController(
            AppDbContext context,
            CurrencyService currency,
            IPricingStrategy pricing)
        {
            _context = context;
            _currency = currency;
            _pricing = pricing;
        }

        // =========================
        // LIST ALL REQUESTS
        // =========================
        public IActionResult Index()
        {
            var data = _context.ServiceRequests
                .Include(s => s.Contract)
                .ToList();

            return View(data);
        }

        // =========================
        // GET CREATE PAGE
        // =========================
        public IActionResult Create()
        {
            ViewBag.Contracts = _context.Contracts.ToList();
            return View();
        }

        // =========================
        // POST CREATE REQUEST
        // =========================
        [HttpPost]
        public async Task<IActionResult> Create(ServiceRequest request)
        {
            // reload dropdown
            ViewBag.Contracts = _context.Contracts.ToList();

            // validation check
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            // get selected contract
            var contract = _context.Contracts
                .FirstOrDefault(c => c.ContractId == request.ContractId);

            if (contract == null)
            {
                ModelState.AddModelError("", "Invalid contract selected.");
                return View(request);
            }

            // ❌ BLOCK expired contracts
            if (contract.Status == "Expired")
            {
                ModelState.AddModelError("", "Cannot create request for expired contract.");
                return View(request);
            }

            // 🌍 API call (async/await)
            var rate = await _currency.GetUsdToZar();

            // 💰 Strategy pattern calculation
            request.CostZAR = _pricing.Calculate(request.CostUSD, rate);

            // ✅ FIXED: prevent NULL error
            request.Status = "Pending";

            // save
            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
