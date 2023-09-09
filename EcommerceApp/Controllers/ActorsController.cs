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
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            //actors_movies is null and id = 0 jer u suprotnom jebe lud budalu.
            if (!ModelState.IsValid && actor.Actors_Movies != null && actor.Id != 0)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction("Index");
        }

        //GET Actors/Details/id
        public async Task<IActionResult> Details(int id)
        { 
            var data = await _service.GetByIdAsync(id);

            if (data == null) 
            {
                return View("Empty"); 
            } else
            {
                return View("ActorDetails",data);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
            {
                return View("Empty");
            }
            else
            {
                return View("Edit", data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor) 
        {
            if (!ModelState.IsValid && actor.Actors_Movies != null)
            {
                return View(actor);
            }
            else
            {
                await _service.UpdateAsync(id, actor);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
            {
                return View("NotFound");
            }
            else
            {
                return View("Delete", data);
                //await _service.DeleteAsync(id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
            {
                return View("NotFound");
            }
            else
            {
                await _service.DeleteAsync(id);
                return RedirectToAction("Actors");
            }
        }
        //Get: Actors/Delete/1
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var actorDetails = await _service.GetByIdAsync(id);
        //    if (actorDetails == null) return View("NotFound");
        //    return View(actorDetails);
        //}

        //[HttpPost/*, ActionName("Delete")*/]
        //public async Task<IActionResult> Remove(int id)
        //{
        //    var actorDetails = await _service.GetByIdAsync(id);
        //    if (actorDetails == null) return View("NotFound");

        //    await _service.DeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
