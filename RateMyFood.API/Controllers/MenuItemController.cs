using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;
using RateMyFood.API.Services;

namespace RateMyFood.API.Controllers
{
    [Route("api/menuitem")]
    public class MenuItemController : ApiBaseController
    {
        #region fields
        private readonly MenuItemService _menuItemService;
        #endregion

        #region constructor
        public MenuItemController(MenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        #endregion

        #region add
        [HttpPost]
        public async Task<IActionResult> AddMenuItem(MenuItem menuItem)
        {
            try
            {
                await _menuItemService.AddMenuItemAsync(menuItem,
                    User.Claims.Where(c => c.Type == "sub").ToString());

                return Ok();
            }
            catch
            {
                return Unauthorized();
            }
        }
        #endregion

        #region get 
        [HttpGet("{menuItemId}")]
        public async Task<IActionResult> GetMenuItem(string menuItemId)
        {
            var menuItems = await _menuItemService.GetMenuItemAsync(menuItemId);

            return Ok(menuItems);
        }
        #endregion

        #region get by restaurant
        [HttpGet("/restaurant/{restaurantId}")]
        public async Task<IActionResult> GetMenuItemByRestaurant(string restaurantId)
        {
            var menuItems = await _menuItemService.GetMenuItemByRestaurantIdAsync(restaurantId);
            
            return Ok(menuItems);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<IActionResult> UpdateMenuItem(string menuItemId, MenuItem menuItem)
        {
            await _menuItemService.UpdateMenuItemAsync(menuItemId, menuItem);

            return Ok();

        }
        #endregion

        #region delete
        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItem(string menuItemId)
        {
            await _menuItemService.DeleteMenuItemAsync(menuItemId);

            return NoContent();
        }
        #endregion

    }
}
