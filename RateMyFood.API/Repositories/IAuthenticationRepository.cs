using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Dtos;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public interface IAuthenticationRepository : IBaseRepository<User>
    {
        Task<User> Get(string username);
        Task<bool> Update(UserToUpdate userToUpdate, string id);
        bool UserExists(string email, string username);
    }
}
