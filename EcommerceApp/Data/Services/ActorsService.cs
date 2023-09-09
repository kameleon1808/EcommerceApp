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

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var res = await _context.Actors.ToListAsync();
            return res;
            //throw new NotImplementedException();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var data = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);

            return data;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
        //public async Task<Actor> DeleteAsync(int id)
        //{



        //}


    }
}
