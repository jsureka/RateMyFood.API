using Microsoft.EntityFrameworkCore;
using RateMyFood.API.DbContexts;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly RateMyFoodContext _rateMyFoodContext;

        public ReviewRepository( RateMyFoodContext rateMyFoodContext)
        {
            _rateMyFoodContext = rateMyFoodContext;
        }

        public async Task Add(Review review)
        {
            _rateMyFoodContext.Reviews.Add(review);
            await SaveChangesAsync();
        }

        public async Task<List<Review>> Get()
        {
           return await _rateMyFoodContext.Reviews.ToListAsync();
        }

        public async Task<Review> Get(string id)
        {
            return await _rateMyFoodContext.Reviews
                .Where(c => c.Id.ToString() == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Review>> GetByMenuItem(string menuItemId)
        {
            return await _rateMyFoodContext.Reviews
                 .Where(c => c.MenuItemId.ToString() == menuItemId)
                 .ToListAsync();
        }

        public async Task Update(string id, Review review)
        {
            var rev = await Get(id);
            if (rev == null)
            {
                throw new KeyNotFoundException("Review Not Found");
            }
            rev = review;
            await SaveChangesAsync();

        }

        public async Task Delete(string id)
        {
            var rev = await Get(id);
            _rateMyFoodContext?.Reviews.Remove(rev);
            await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _rateMyFoodContext.SaveChangesAsync() >= 0);
        }
    }
}
