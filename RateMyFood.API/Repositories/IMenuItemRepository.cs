using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public interface IMenuItemRepository : IBaseRepository<MenuItem> 
    {
        Task<List<MenuItem>> GetByRestaurant(string restaurantId);
        Task Update(string id, MenuItem menuItemToUpdate);
    }
}
