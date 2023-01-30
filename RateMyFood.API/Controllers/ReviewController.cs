using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;
using RateMyFood.API.Services;

namespace RateMyFood.API.Controllers
{
    [Route("api/review")]
    public class ReviewController : ApiBaseController
    {
        #region fields
        private readonly IReviewService _reviewService;
        #endregion

        #region constructor
        public ReviewController( IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        #endregion

        #region add review
        [HttpPost]
        public async Task<IActionResult> Review(Review review )
        { 
            await _reviewService.AddReviewAsync(review);

            return Ok();
        }
        #endregion

        #region get review
        [HttpGet]
        public async Task<IActionResult> GetReview()
        {
            var reviews = await _reviewService.GetReviewsAsync();

            return Ok(reviews);
        }
        #endregion

        #region get review by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(string id)
        {
            var review = await _reviewService.GetReviewsAsync(id);

            return Ok(review);
        }
        #endregion

        #region get review by id
        [HttpGet("menuItem/{id}")]
        public async Task<IActionResult> GetReviewByMenuItem(string id)
        {
            var review = await _reviewService.GetReviewsByMenuItemAsync(id);

            return Ok(review);
        }
        #endregion

        #region update review
        [HttpPut("{reviewId}")]
        public async Task<IActionResult> UpdateReview(string reviewId, Review review)
        {
            await _reviewService.UpdateReviewAsync(reviewId, review);

            return NoContent();
        }
        #endregion

        #region delete review
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            await _reviewService.DeleteReviewAsync(id);

            return NoContent();
        }
        #endregion
    }
}
