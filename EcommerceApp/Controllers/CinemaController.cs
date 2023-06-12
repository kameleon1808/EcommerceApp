using EcommerceApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CinemaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Cinemas.ToListAsync();
            return View();
        }
    }
}
