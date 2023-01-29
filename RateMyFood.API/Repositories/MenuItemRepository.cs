using Microsoft.EntityFrameworkCore;
using RateMyFood.API.DbContexts;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RateMyFoodContext _rateMyFoodContext;

        public MenuItemRepository( RateMyFoodContext rateMyFoodContext)
        {
            _rateMyFoodContext = rateMyFoodContext 
                ?? throw new ArgumentNullException(nameof(rateMyFoodContext));
        }

        public async Task AddAsync(MenuItem menuItem)
        {
             _rateMyFoodContext.MenuItems.Add(menuItem);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var menuItem = await GetById(id);
            _rateMyFoodContext.MenuItems.Remove(menuItem);
            SaveChangesAsync();
        }

        public Task<List<MenuItem>> Get()
        {
            var menuItems = _rateMyFoodContext.MenuItems.ToListAsync();
            return menuItems;
        }

        public async Task<MenuItem> GetById(string id)
        {
            var menuItem = await _rateMyFoodContext.MenuItems.
                Where(c => c.Id.ToString() == id).FirstOrDefaultAsync();
            return menuItem;
        }

        public async Task<List<MenuItem>> GetByRestaurant(string restaurantId)
        {
            var menuItemsByRestaurant =await _rateMyFoodContext.MenuItems
                .Where(c => c.RestaurantId == restaurantId).ToListAsync();
            return menuItemsByRestaurant;
        }

        public async Task Update(string id, MenuItem menuItemToUpdate)
        {
            var res = await GetById(id);
            if (res == null)
            {
                throw new KeyNotFoundException("Item Not Found");
            }
            res.Name = menuItemToUpdate.Name;
            res.Description = menuItemToUpdate.Description;
            res.Ingredients = menuItemToUpdate.Ingredients;
            await _rateMyFoodContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _rateMyFoodContext.SaveChangesAsync() >= 0) ;
        }

    }
}
