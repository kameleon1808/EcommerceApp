using EcommerceApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context; 
        public MoviesController(ApplicationDbContext context) {  _context = context; }
        public async Task<IActionResult> IndexAsync()
        {
            var data = await _context.Movies.Include(n => n.Cinema).OrderBy(n=>n.Name).ToListAsync();

            return View(data);
        }
    }
}
