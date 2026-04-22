using Microsoft.AspNetCore.Mvc;

using GLMS.Data;
using GLMS.Models;

namespace GLMS.Controllers
{

    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Clients.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            _context.Clients.Add(client);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}