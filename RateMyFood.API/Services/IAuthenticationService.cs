using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Services
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateUserAsync(string username, string password);
        Task<User> RegisterUserAsync(User user);
        Task<bool> SaveChangesAsync();
    }
}
