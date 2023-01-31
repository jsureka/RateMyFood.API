using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Add a restaurant (Admin)
        /// </summary>
        /// <param name="restaurant">The Restaurant Object</param>
        /// <returns>An IActionResult containing a string</returns>
        /// <response code="200">Returns string</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRestaurant(Restaurant restaurant)
        {
            await _restaurantService.AddRestaurantAsync(restaurant);
            return Ok("Restaurant Created");
        }
        #endregion

        #region get all
        /// <summary>
        /// Get info of all restaurants
        /// </summary>
        /// <returns>An IActionResult with restaurant list</returns>
        /// <response code="200">Returns list of restaurant</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <response code="200">Returns list of restaurant</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <response code="200">Returns restaurant object</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <response code="204">Returns No Content</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        /// <response code="204">Returns No Content</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
