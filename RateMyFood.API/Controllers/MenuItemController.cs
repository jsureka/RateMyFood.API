using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;
using RateMyFood.API.Services;
using Serilog;
using System.Security.Claims;

namespace RateMyFood.API.Controllers
{
    public class MenuItemController : ApiBaseController
    {
        #region fields
        private readonly IMenuItemService _menuItemService;
        #endregion

        #region constructor
        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        #endregion

        #region add
        /// <summary>
        /// Add a menu Item to a restaurant (Restaurant Owner)
        /// </summary>
        /// <param name="menuItem">The object menuItem</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">No Content</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> AddMenuItem(MenuItem menuItem)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var id = claimsIdentity.FindFirst("sub").Value;
            await _menuItemService.AddMenuItemAsync(menuItem,
                    id.ToString());

                return CreatedAtRoute("GetMenuItem", menuItem.Id.ToString(), menuItem);
        }
        #endregion

        #region get 
        /// <summary>
        /// Get info of a menu item 
        /// </summary>
        /// <param name="menuItemId">The Id of menu Item</param>
        /// <returns>An IActionResult containing the users</returns>
        /// <response code="200">Returns menu item object</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{menuItemId}" , Name = "GetMenuItem")]
        public async Task<IActionResult> GetMenuItem([FromRoute] string menuItemId)
        {
            var menuItems = await _menuItemService.GetMenuItemAsync(menuItemId);

            return Ok(menuItems);
        }
        #endregion

        #region search menu item
        /// <summary>
        /// Search a menu item by name
        /// </summary>
        /// <param name="menuItemName">The search query</param>
        /// <returns>An IActionResult containing the menuItems List</returns>
     
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("search")]
        public async Task<IActionResult> SearchMenuItem([FromQuery] string menuItemName)
        {
            var menuItems = await _menuItemService.SearchMenuItemAsync(menuItemName);

            return Ok(menuItems);
        }
        #endregion

        #region get by restaurant
        /// <summary>
        /// Get info of menu items of a restaurant
        /// </summary>
        /// <param name="restaurantId">The Id of restaurant</param>
        /// <returns>An IActionResult containing the users</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetMenuItemByRestaurant(string restaurantId)
        {
            var menuItems = await _menuItemService.GetMenuItemByRestaurantIdAsync(restaurantId);
            
            return Ok(menuItems);
        }
        #endregion

        #region update
        /// <summary>
        /// Update a menu item (restaurant owner)
        /// </summary>
        /// <param name="menuItemId">The Id of menu Item</param>
        /// <param name="menuItem">The update object of menu Item</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<IActionResult> UpdateMenuItem(string menuItemId, MenuItem menuItem)
        {
            await _menuItemService.UpdateMenuItemAsync(menuItemId, menuItem);

            return Ok();

        }
        #endregion

        #region delete
        /// <summary>
        /// Delete a menu item (Restaurant Owner) 
        /// </summary>
        /// <param name="menuItemId">The Id of menu Item</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItem(string menuItemId)
        {
            await _menuItemService.DeleteMenuItemAsync(menuItemId);

            return NoContent();
        }
        #endregion

    }
}
