using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;
using RateMyFood.API.Models;
using RateMyFood.API.Services;

namespace RateMyFood.API.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ApiBaseController
    {
        #region fields
        private readonly IRestaurantService _restaurantService;
        #endregion

        #region contructor
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        #endregion

        #region add 
        [HttpPost]
        public async Task<IActionResult> AddRestaurant(Restaurant restaurant)
        {
            await _restaurantService.AddRestaurantAsync(restaurant);
            return Ok("Restaurant Created");
        }
        #endregion

        #region get all
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetRestaurantAsync();
            return Ok(restaurants);
        }
        #endregion

        #region get all
        [HttpGet("/search")]
        public async Task<IActionResult> SearchRestaurant([FromQuery] string searchstring)
        {
            var restaurants = await _restaurantService.SearchRestaurantAsync(searchstring);

            return Ok(restaurants);
        }
        #endregion 

        #region get single 
        [HttpGet("{id}", Name = "GetSingleRestaurant")]
        public async Task<IActionResult> GetSingleRestaurant(string id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            return Ok(restaurant);
        }
        #endregion

        #region update 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(string id, 
            RestaurantDto restaurantDto)
        {
            await _restaurantService.UpdateRestaurantAsync(id, restaurantDto);
            return NoContent();
        }
        #endregion

        #region delete 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(string id)
        {
            await _restaurantService.DeleteRestaurantAsync(id);
            return NoContent();
        }
        #endregion
    }
}
