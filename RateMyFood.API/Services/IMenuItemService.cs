using RateMyFood.API.Entities;

namespace RateMyFood.API.Services
{
    public interface IMenuItemService
    {
        public Task AddMenuItemAsync(MenuItem menuItem, string userId);
        public Task<List<MenuItem>> GetMenuItemAsync();
        public Task<MenuItem> GetMenuItemAsync(string id);
        public Task<List<MenuItem>> GetMenuItemByRestaurantIdAsync(string restaurantId);
        public Task<List<MenuItem>> SearchMenuItemAsync(string searchdata);
        public Task UpdateMenuItemAsync(
            string menuItemId, MenuItem menuItem);
        public Task DeleteMenuItemAsync(string menuItemId);
    }
}
