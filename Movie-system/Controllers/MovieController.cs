using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_system.Models;

namespace Movie_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieSystemContext _dbContext;
        public MovieController(MovieSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<List<Movie>>> GetMovieByUserId()
        {
            var movie = await _dbContext.Movies
                .Select(m => new
                {
                    m.MovieId,
                    m.MovieTitle,
                    m.MovieDescription,
                    m.MovieLink,
                    m.MovieUserId
                })
                .ToListAsync();

            return Ok(movie);
        }

        [HttpGet("GetMovieByUserId/{MovieUserId}")]
        public async Task<ActionResult<List<Movie>>> GetMovieByMovieUserId(int MovieUserId)
        {
            var movies = await _dbContext.Movies
                .Where(m => m.MovieUserId == MovieUserId)
                .Select(m => new
                {
                    m.MovieTitle, m.MovieLink
                })
                .ToListAsync();

            return Ok(movies);
        }

        [HttpPost("AddNewMovie/{MovieTitle}/{MovieLink}/{MovieUserId}")]
        public async Task<IActionResult> AddNewMovie(string MovieTitle, string MovieLink, int MovieUserId)
        {
            try
            {
                var existingMovies = await _dbContext.Movies
                    .FirstOrDefaultAsync(m => m.MovieLink == MovieLink && m.MovieTitle == MovieTitle);

                if (existingMovies != null)
                {
                    return BadRequest("This has already been added to the database.");
                }

                var aMovieUserId = await _dbContext.Users.FindAsync(MovieUserId);

                if (aMovieUserId != null)
                {
                    return BadRequest("This genre is invalid.");
                }

                var newMovie = new Movie
                {
                    MovieTitle = MovieTitle,
                    MovieLink = MovieLink,
                    MovieUserId = MovieUserId
                };

                _dbContext.Movies.Add(newMovie);
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
