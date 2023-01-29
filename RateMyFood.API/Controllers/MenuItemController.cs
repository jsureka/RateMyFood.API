using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;
using RateMyFood.API.Services;

namespace RateMyFood.API.Controllers
{
    [Route("api/restaurant")]
    public class MenuItemController : ApiBaseController
    {
        private readonly MenuItemService _menuItemService;

        public MenuItemController( MenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMenuItem(MenuItem menuItem)
        {
            try
            {
                await _menuItemService.AddMenuItemAsync(menuItem,
                    User.Claims.Where( c => c.Type == "sub").ToString());

                return Ok();
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItem(string restaurantId)
        {
            var menuItems = await _menuItemService.GetMenuItemByRestaurantIdAsync(restaurantId);
            
            return Ok(menuItems);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuItem(string menuItemId, MenuItem menuItem)
        {
            await _menuItemService.UpdateMenuItemAsync(menuItemId, menuItem);

            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenuItem(string menuItemId)
        {
            await _menuItemService.DeleteMenuItemAsync(menuItemId);

            return NoContent();
        }

        
    }
}
