using RateMyFood.API.Entities;
using RateMyFood.API.Repositories;

namespace RateMyFood.API.Services
{
    public class MenuItemService : IMenuItemService
    {
        #region fields
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        #endregion

        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            await _menuItemRepository.AddAsync(menuItem);
            await _menuItemRepository.SaveChangesAsync(); 

        }

        public async Task DeleteMenuItemAsync(string menuItemId)
        {
            var menuItem = await  _menuItemRepository.GetById(menuItemId);
            if(menuItem == null)
            {
                throw new NullReferenceException("Menu Item Not Found");
            }
            await _menuItemRepository.DeleteAsync(menuItemId);
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
            var restaurant = this._restaurantRepository.GetById(restaurantId);
            if( restaurant == null)
            {
                throw new NullReferenceException();
            }
            return await _menuItemRepository.GetByRestaurant( restaurantId);
        }

        public async Task UpdateMenuItemAsync(string menuItemId, MenuItem menuItem)
        {
            var item = await _menuItemRepository.GetById(menuItemId);
            if(item is null )
            {
                throw new NullReferenceException("Menu Item Not Found");
            }
            await _menuItemRepository.Update(menuItemId, menuItem);
        }
    }
}
