using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateMyFood.API.DbContexts;
using RateMyFood.API.Dtos;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public class AuthenticationRepository :BaseRepository<User>, IAuthenticationRepository
    {
        private readonly RateMyFoodContext _rateMyFoodContext;

        public AuthenticationRepository(RateMyFoodContext rateMyFoodContext) : base(rateMyFoodContext)
        {
            _rateMyFoodContext = rateMyFoodContext;
        }

        public async Task<User> Get(string username)
        {

#pragma warning disable CS8603 // Possible null reference return.
            return await _rateMyFoodContext.Users.Where(i => i.UserName == username
            ).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<bool> Update(UserToUpdate userToUpdate, string id)
        {
            var res = _rateMyFoodContext.Users.
                Where(c => c.Id.ToString() == id).FirstOrDefault();
            if (res != null)
            {
                res.UserName = userToUpdate.UserName;
                res.FirstName = userToUpdate.FirstName;
                res.LastName = userToUpdate.LastName;
                res.Email = userToUpdate.Email;
                await _rateMyFoodContext.SaveChangesAsync();
            }
            return true;
        }

        public bool UserExists(string email, string username)
        {
            return _rateMyFoodContext.Users.Any(
                c => c.UserName == username || c.Email == email);
        }

    }
}
