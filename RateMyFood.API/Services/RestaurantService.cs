using AutoMapper;
using RateMyFood.API.Entities;
using RateMyFood.API.Models;
using RateMyFood.API.Repositories;

namespace RateMyFood.API.Services
{
    public class RestaurantService : IRestaurantService
    {
        #region fields
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;
        #endregion

        public RestaurantService(IRestaurantRepository restaurantRepository,
            IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.AddAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(string restaurantId)
        {
            await _restaurantRepository.DeleteAsync(restaurantId);
        }

        public async Task<List<Restaurant>> GetRestaurantAsync()
        {
            return await _restaurantRepository.Get();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(string restaurantId)
        {
            return await _restaurantRepository.GetById(restaurantId);
        }

        public async Task<List<Restaurant>> SearchRestaurantAsync(string searchstring)
        {
            var restaurants = await _restaurantRepository.Get();
            return restaurants.Where( c => c.Name.Contains(searchstring) ).ToList();
        }

        public async Task UpdateRestaurantAsync(string restaurantId, RestaurantDto restaurantToUpdate)
        {
            await _restaurantRepository.Update(restaurantId, restaurantToUpdate);
        }
    }
}
