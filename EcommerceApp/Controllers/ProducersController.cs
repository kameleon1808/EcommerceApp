using EcommerceApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class ProducersController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public ProducersController(ApplicationDbContext context) {  _context = context; }
        public IActionResult Index()
        {
            var prod = _context.Producers.ToList();
            return View();
        }
    }
}
