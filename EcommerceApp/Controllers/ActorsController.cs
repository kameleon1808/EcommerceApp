using EcommerceApp.Data;
using EcommerceApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Models;

namespace EcommerceApp.Controllers
{
    public class ActorsController : Controller
    {
        
        //private readonly ApplicationDbContext _context;
        private readonly IActorsService _service;

        //ctor key shortcut
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        //[BindProperties]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}
            //_service.Add(actor);
            //return View("Index");
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            _service.Add(actor);
            return RedirectToAction("Index");

        }
    }
}
