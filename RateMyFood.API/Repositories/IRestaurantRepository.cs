using RateMyFood.API.Entities;
using RateMyFood.API.Models;

namespace RateMyFood.API.Repositories
{
    public interface IRestaurantRepository
    {
        Task AddAsync(Restaurant restaurant);
        Task<List<Restaurant>> Get();
        Task<Restaurant> GetById(string id);
        Task Update(string id, RestaurantDto restaurantToUpdate);
        Task DeleteAsync(string id);
        Task<bool> SaveChangesAsync();

    }
}
