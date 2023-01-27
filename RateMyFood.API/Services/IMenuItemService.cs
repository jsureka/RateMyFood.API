using RateMyFood.API.Entities;

namespace RateMyFood.API.Services
{
    public interface IMenuItemService
    {
        public Task AddMenuItemAsync(MenuItem menuItem);
        public Task<List<MenuItem>> GetMenuItemAsync();
        public Task<MenuItem> GetMenuItemByIdAsync(string menuItemId);
        public Task UpdateMenuItemAsync(
            string menuItemId, MenuItem menuItem);
        public Task DeleteMenuItemAsync(string menuItemId);
    }
}
