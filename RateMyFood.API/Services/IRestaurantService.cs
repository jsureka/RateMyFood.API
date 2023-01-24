using RateMyFood.API.Entities;
using RateMyFood.API.Models;

namespace RateMyFood.API.Services
{
    public interface IRestaurantService
    {

        public Task AddRestaurantAsync(Restaurant restaurant);
        public Task<List<Restaurant>> GetRestaurantAsync();
        public Task<Restaurant> GetRestaurantByIdAsync(string restaurantId);
        public Task UpdateRestaurantAsync(
            string restaurantId, RestaurantDto restaurantToUpdate);
        public Task DeleteRestaurantAsync(string restaurantId);


    }
}
