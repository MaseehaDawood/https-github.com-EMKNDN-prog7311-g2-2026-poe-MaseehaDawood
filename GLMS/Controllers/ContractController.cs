using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GLMS.Data;
using GLMS.Models;

namespace GLMS.Controllers
{

    public class ContractController : Controller
    {
        private readonly AppDbContext _context;

        public ContractController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string status)
        {
            var contracts = _context.Contracts.Include(c => c.Client).AsQueryable();

            if (!string.IsNullOrEmpty(status))
                contracts = contracts.Where(c => c.Status == status);

            return View(contracts.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Clients = _context.Clients.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contract contract, IFormFile file)
        {
            ViewBag.Clients = _context.Clients.ToList();

            if (!ModelState.IsValid)
            {
                return View(contract);
            }

            if (file != null && file.Length > 0)
            {
                var ext = Path.GetExtension(file.FileName).ToLower();

                if (ext != ".pdf")
                {
                    ModelState.AddModelError("", "Only PDF files are allowed.");
                    return View(contract);
                }

                var fileName = Guid.NewGuid().ToString() + ".pdf";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                contract.FilePath = "/files/" + fileName;
            }

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
