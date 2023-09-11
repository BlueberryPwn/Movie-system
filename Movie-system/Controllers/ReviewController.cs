using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_system.Models;

namespace Movie_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly MovieSystemContext _dbContext;
        public ReviewController(MovieSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetReviewByUserId/{UserId}")]
        public async Task<ActionResult<List<Reviews>>> GetReviewRatingByUserId(int UserId)
        {
            var reviews = await _dbContext.Reviews
                .Where(r => r.UserId == UserId)
                .Select(r => new
                {
                    r.ReviewName,
                    r.ReviewRating
                })
                .ToListAsync();

            return Ok(reviews);
        }

        [HttpPost("AddReview/{UserId}/{MovieId}/{ReviewRating}/{ReviewName}")]
        public async Task<IActionResult> AddReview(string ReviewName, int ReviewRating, int MovieId, int UserId)
        {
            try
            {
                var existingReviewRating = await _dbContext.Reviews
                    .FirstOrDefaultAsync(r => r.UserId == UserId && r.ReviewName == ReviewName);

                if (existingReviewRating != null)
                {
                    return BadRequest("You have already given a review for this movie.");
                }

                var user = await _dbContext.Users.FindAsync(UserId);
                var movie = await _dbContext.Movies.FindAsync(MovieId);

                if (user == null || movie == null)
                {
                    return BadRequest("This user or movie doesn't exist.");
                }

                var newReview = new Reviews
                {
                    ReviewName = ReviewName,
                    ReviewRating = ReviewRating,
                    MovieId = MovieId,
                    UserId = UserId
                };

                _dbContext.Reviews.Add(newReview);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"ERROR: {ex.Message}");
            }
        }
    }
}
