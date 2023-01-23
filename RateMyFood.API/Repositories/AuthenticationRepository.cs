using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateMyFood.API.DbContexts;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly RateMyFoodContext _rateMyFoodContext;

        public AuthenticationRepository(RateMyFoodContext rateMyFoodContext)
        {
            this._rateMyFoodContext = rateMyFoodContext;
        }


        public async void Add(User user)
        {
            await _rateMyFoodContext.Users.AddAsync(user);
        }

        public void Delete(Guid id)
        {
            _rateMyFoodContext.Remove(id);
        }

        public async Task<User> Get(string username)
        {

#pragma warning disable CS8603 // Possible null reference return.
            return await _rateMyFoodContext.Users.Where(i => i.UserName == username
            ).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<List<User>> Get()
        {

#pragma warning disable CS8603 // Possible null reference return.
            return await _rateMyFoodContext.Users.ToListAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<User> GetById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _rateMyFoodContext.Users.Where(c => c.Id == id)
                .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _rateMyFoodContext.SaveChangesAsync() >= 0);
        }

        public Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }

        public bool UserExists(User user)
        {
            return  _rateMyFoodContext.Users.Any( 
                c => c.UserName == user.UserName || c.Email == user.Email);
        }
    }
}
