using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Dtos;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Services
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateUserAsync(string username, string password);
        Task<bool> RegisterUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(string id);
        Task<bool> SaveChangesAsync();
        Task<bool> UpdateUserAsync(UserToUpdate userToUpdate, string id);
        void DeleteUser(string id);
    }
}
