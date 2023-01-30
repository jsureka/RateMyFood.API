using RateMyFood.API.Entities;
using RateMyFood.API.Repositories;

namespace RateMyFood.API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMenuItemService _menuItemService;

        public ReviewService(IReviewRepository reviewRepository, IMenuItemService menuItemService)
        {
            _reviewRepository = reviewRepository;
            _menuItemService = menuItemService;
        }

        public async Task AddReviewAsync(Review review)
        {
            var menuItem = await _menuItemService.GetMenuItemAsync(review.MenuItemId);
            if(menuItem == null)
            {
                throw new NullReferenceException("Menu Item not Found");
            }
            await _reviewRepository.Add(review);
        }

        public async Task DeleteReviewAsync(string reviewId)
        {
            var review = await _reviewRepository.Get(reviewId);
            if (review == null)
            {
                throw new NullReferenceException("Review not Found");
            }
           await _reviewRepository.Delete(reviewId);

        }

        public async Task<List<Review>> GetReviewsAsync()
        {
            return await _reviewRepository.Get();
        }

        public async Task<Review> GetReviewsAsync(string id)
        {
            return await _reviewRepository.Get(id);
        }

        public async Task<List<Review>> GetReviewsByMenuItemAsync(string menuItemId)
        {
            return await _reviewRepository.GetByMenuItem(menuItemId);
        }

        public async Task UpdateReviewAsync(string reviewId, Review review)
        {
            var rev = await _reviewRepository.Get(reviewId);
            if(rev == null)
            {
                throw new NullReferenceException("Not Found");
            }
            await _reviewRepository.Update(reviewId, review);
        }
    }
}
