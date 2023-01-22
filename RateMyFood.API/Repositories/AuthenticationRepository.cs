using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public Task<IActionResult> Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Get(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }
    }
}
