using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public interface IAuthenticationRepository
    {
        void Add(User user);
        Task<List<User>> Get();
        Task<User> Get(string username);
        Task<IActionResult> Update();
        void Delete(Guid id);
        Task<User> GetById(Guid id);
        bool UserExists(User user);
        Task<bool> SaveChangesAsync();
    }
}
