using RateMyFood.API.Entities;

namespace RateMyFood.API.Services
{
    public interface IReviewService
    {
        public Task AddReviewAsync(Review review);
        public Task<List<Review>> GetReviewsAsync();
        public Task<Review> GetReviewsAsync(string id);
        public Task<List<Review>> GetReviewsByMenuItemAsync(string menuItemId);
        public Task UpdateReviewAsync(
            string reviewId, Review review);
        public Task DeleteReviewAsync(string reviewId);
    }
}
