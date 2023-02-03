using Microsoft.EntityFrameworkCore;
using RateMyFood.API.DbContexts;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        private readonly RateMyFoodContext _rateMyFoodContext;

        public MenuItemRepository( RateMyFoodContext rateMyFoodContext) : base(rateMyFoodContext)
        {
            _rateMyFoodContext = rateMyFoodContext 
                ?? throw new ArgumentNullException(nameof(rateMyFoodContext));
        }

        public async Task<List<MenuItem>> GetByRestaurant(string restaurantId)
        {
            var menuItemsByRestaurant =await _rateMyFoodContext.MenuItems
                .Where(c => c.RestaurantId == restaurantId).ToListAsync();
            return menuItemsByRestaurant;
        }

        public async Task Update(string id, MenuItem menuItemToUpdate)
        {
            var res =  GetById(id);
            if (res == null)
            {
                throw new KeyNotFoundException("Item Not Found");
            }
            res.Name = menuItemToUpdate.Name;
            res.Description = menuItemToUpdate.Description;
            await _rateMyFoodContext.SaveChangesAsync();
        }
    }
}
