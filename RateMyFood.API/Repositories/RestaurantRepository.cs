using Microsoft.EntityFrameworkCore;
using RateMyFood.API.DbContexts;
using RateMyFood.API.Entities;
using RateMyFood.API.Models;

namespace RateMyFood.API.Repositories
{

    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RateMyFoodContext _rateMyFoodContext;

        public RestaurantRepository(RateMyFoodContext rateMyFoodContext)
        {
            _rateMyFoodContext = rateMyFoodContext;
        }
        public async Task AddAsync(Restaurant restaurant)
        {
            _rateMyFoodContext.Restaurants.Add(restaurant);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var restaurant = await GetById(id);
            _rateMyFoodContext.Restaurants.Remove(restaurant);
            SaveChangesAsync();
        }

        public async Task<List<Restaurant>> Get()
        {
            return await _rateMyFoodContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetById(string id)
        {
            return await _rateMyFoodContext.Restaurants
                .Where(c => c.Id.ToString() == id).FirstOrDefaultAsync();

        }

        public async Task Update(string id, RestaurantDto restaurantToUpdate)
        {
            var res = await GetById(id);
            if (res == null)
            {
                throw new KeyNotFoundException("Restaurant Not Found");
            }
            res.Name = restaurantToUpdate.Name;
            res.Address = restaurantToUpdate.Address;
            await _rateMyFoodContext.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _rateMyFoodContext.SaveChangesAsync() >= 0);
        }
    }
}
