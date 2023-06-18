using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly ApplicationDbContext _context;
        public ActorsService(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public void Add(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var res = await _context.Actors.ToListAsync();
            return res;
            //throw new NotImplementedException();
        }

        public Actor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
