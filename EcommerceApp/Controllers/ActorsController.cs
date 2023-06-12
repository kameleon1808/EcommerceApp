using EcommerceApp.Data;
using Microsoft.AspNetCore.Mvc;

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

            var data = await _context.Actors.ToList();
            return View();
        }
    }
}
