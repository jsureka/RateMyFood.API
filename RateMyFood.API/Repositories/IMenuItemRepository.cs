using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public interface IMenuItemRepository
    {
        Task AddAsync(MenuItem menuItem);
        Task<List<MenuItem>> Get();
        Task<MenuItem> GetById(string id);
        Task<List<MenuItem>> GetByRestaurant(string restaurantId);
        Task Update(string id, MenuItem menuItemToUpdate);
        Task DeleteAsync(string id);
        Task<bool> SaveChangesAsync();
    }
}
