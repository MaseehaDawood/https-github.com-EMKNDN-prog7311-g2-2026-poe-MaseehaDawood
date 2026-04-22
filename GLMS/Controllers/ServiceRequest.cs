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

        public ServiceRequestController(AppDbContext context, CurrencyService currency, IPricingStrategy pricing)
        {
            _context = context;
            _currency = currency;
            _pricing = pricing;
        }

        public IActionResult Index()
        {
            var data = _context.ServiceRequests.Include(s => s.Contract);
            return View(data.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Contracts = _context.Contracts.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceRequest request)
        {
            ViewBag.Contracts = _context.Contracts.ToList();

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var contract = _context.Contracts.Find(request.ContractId);

            if (contract.Status == "Expired")
            {
                ModelState.AddModelError("", "Cannot create request for expired contract.");
                return View(request);
            }

            var rate = await _currency.GetUsdToZar();
            request.CostZAR = _pricing.Calculate(request.CostUSD, rate);


            request.Status = "Pending";

            _context.ServiceRequests.Add(request);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
