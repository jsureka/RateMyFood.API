using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public interface IReviewRepository
    {
        Task Add(Review review);
        Task<List<Review>> Get();
        Task<Review> Get(string id);
        Task<List<Review>> GetByMenuItem(string menuItemId);
        Task Update(string id, Review review);
        Task Delete(string id);
        Task<bool> SaveChangesAsync();
    }
}
