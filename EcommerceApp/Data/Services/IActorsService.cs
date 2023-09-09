using EcommerceApp.Models;

namespace EcommerceApp.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor); //insert
        Task<Actor> UpdateAsync(int id, Actor newActor);
        Task DeleteAsync(int id);
    }
}
