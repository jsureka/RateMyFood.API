using RateMyFood.API.Entities;
using RateMyFood.API.Repositories;

namespace RateMyFood.API.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService( IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.AddAsync(menuItem);
        }

        public Task DeleteMenuItemAsync(string menuItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuItem>> GetMenuItemAsync()
        {
            return await _menuItemRepository.Get();
        }

        public async Task<MenuItem> GetMenuItemAsync(string id)
        {
            return await _menuItemRepository.GetById(id);
        }


        public async Task<List<MenuItem>> GetMenuItemByRestaurantIdAsync(string restaurantId)
        {
            return await _menuItemRepository.GetByRestaurant( restaurantId);
        }



        public Task UpdateMenuItemAsync(string menuItemId, MenuItem menuItem)
        {
            throw new NotImplementedException();
        }
    }
}
