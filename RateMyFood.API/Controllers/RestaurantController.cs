using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;
using RateMyFood.API.Models;
using RateMyFood.API.Services;

namespace RateMyFood.API.Controllers
{
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
       /// <summary>
       /// Add a new restaurant
       /// </summary>
       /// <param name="restaurant"></param>
       /// <returns></returns>
       
        [ProducesResponseType(statusCode : StatusCodes.Status201Created, type:typeof(Restaurant))]
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRestaurant(Restaurant restaurant)
        {
            await _restaurantService.AddRestaurantAsync(restaurant);

            return CreatedAtRoute("GetSingleRestaurant", restaurant.Id.ToString(), restaurant);
        }
        #endregion

        #region get all
        /// <summary>
        /// Get info of all restaurants
        /// </summary>
        /// <returns>An IActionResult with restaurant list</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetRestaurantAsync();
            return Ok(restaurants);
        }
        #endregion

        #region search restaurant
        /// <summary>
        /// Search for a restaurant with name
        /// </summary>
        /// <param name="restaurantName">The search string</param>
        /// <returns>An IActionResult containing matched restaurants</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("search")]
        public async Task<IActionResult> SearchRestaurant([FromQuery] string restaurantName)
        {
            var restaurants = await _restaurantService.SearchRestaurantAsync(restaurantName);

            return Ok(restaurants);
        }
        #endregion

        #region get single 
        /// <summary>
        /// Get info of a single restaurant
        /// </summary>
        /// <param name="id">The Id of restaurant</param>
        /// <returns>An IActionResult contanining the restaurant</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}", Name = "GetSingleRestaurant")]
        public async Task<IActionResult> GetSingleRestaurant([FromRoute] string id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            return Ok(restaurant);
        }
        #endregion

        #region update 
        /// <summary>
        /// Update restaurant (Admin)
        /// </summary>
        /// <param name="id">The Id of restaurant</param>
        /// <param name="restaurantDto">The object of updated restaurant</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRestaurant(string id, 
            RestaurantDto restaurantDto)
        {
            await _restaurantService.UpdateRestaurantAsync(id, restaurantDto);
            return NoContent();
        }
        #endregion

        #region delete 
        /// <summary>
        /// Delete restaurant (Admin)
        /// </summary>
        /// <param name="id">The Id of restaurant</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRestaurant(string id)
        {
            await _restaurantService.DeleteRestaurantAsync(id);
            return NoContent();
        }
        #endregion
    }
}
