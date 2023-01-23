using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Dtos;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public interface IAuthenticationRepository
    {
        void Add(User user);
        Task<List<User>> Get();
        Task<User> Get(string username);
        Task<bool> Update(UserToUpdate userToUpdate, string id);
        void Delete(string id);
        Task<User> GetById(string id);
        bool UserExists(string email, string username);
        Task<bool> SaveChangesAsync();
    }
}
