using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Services
{
    public interface IAuthenticationService
    {
        Task<IActionResult> AuthenticateUserAsync(string username, string password);
        Task<IActionResult> RegisterUserAsync(User user);
        Task<bool> SaveChangesAsync();
    }
}
