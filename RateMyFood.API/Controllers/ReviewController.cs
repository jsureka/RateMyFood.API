using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;
using RateMyFood.API.Services;

namespace RateMyFood.API.Controllers
{
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
        /// <summary>
        ///  Add a review for a menu Item
        /// </summary>
        /// <param name="review">The review object</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Review(Review review )
        { 
            await _reviewService.AddReviewAsync(review);

            return CreatedAtRoute("GetSingleReview", review.Id.ToString(), review);
        }
        #endregion

        #region get review
        /// <summary>
        /// Get all reviews 
        /// </summary>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetReview()
        {
            var reviews = await _reviewService.GetReviewsAsync();

            return Ok(reviews);
        }
        #endregion

        #region get review by id
        /// <summary>
        /// Get review by Id
        /// </summary>
        /// <param name="id">The Id of review</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}", Name = "GetSingleReview")]
        public async Task<IActionResult> GetReview(string id)
        {
            var review = await _reviewService.GetReviewsAsync(id);

            return Ok(review);
        }
        #endregion

        #region get review by menu item
        /// <summary>
        /// Get review by menu item id
        /// </summary>
        /// <param name="id">The Id of menu item</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("menuItem/{id}")]
        public async Task<IActionResult> GetReviewByMenuItem(string id)
        {
            var review = await _reviewService.GetReviewsByMenuItemAsync(id);

            return Ok(review);
        }
        #endregion

        #region update review
        /// <summary>
        /// Update a review
        /// </summary>
        /// <param name="reviewId">The Id of review</param>
        /// <param name="review">The udpated review object</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{reviewId}")]
        public async Task<IActionResult> UpdateReview(string reviewId, Review review)
        {
            await _reviewService.UpdateReviewAsync(reviewId, review);

            return NoContent();
        }
        #endregion

        #region delete review
        /// <summary>
        /// Delete a review
        /// </summary>
        /// <param name="id">The Id of review</param>
        /// <returns>An IActionResult</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            await _reviewService.DeleteReviewAsync(id);

            return NoContent();
        }
        #endregion
    }
}
