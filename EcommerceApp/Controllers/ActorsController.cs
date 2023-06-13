using EcommerceApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        //ctor key shortcut
        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var data = await _context.Actors.ToListAsync();
            return View();
        }
    }
}
