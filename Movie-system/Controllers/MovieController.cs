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
        public async Task<ActionResult<List<Movies>>> GetAllMovies()
        {
            var movies = await _dbContext.Movies
                .Select(m => new
                {
                    m.MovieId,
                    m.MovieName,
                    m.MovieGenre,
                    m.MovieDescription,
                    m.Link,
                    m.UserId
                })
                .ToListAsync();

            return Ok(movies);
        }

        [HttpGet("GetMovieByUserId/{UserId}")]
        public async Task<ActionResult<List<Movies>>> GetMovieByUserId(int UserId)
        {
            var movies = await _dbContext.Movies
                .Where(m => m.UserId == UserId)
                .Select(m => new
                {
                    m.MovieName,
                    m.MovieGenre,
                    m.Link
                })
                .ToListAsync();

            return Ok(movies);
        }

        [HttpPost("AddNewMovie/{MovieName}/{MovieGenre}/{MovieDescription}/{Link}/{UserId}")]
        public async Task<IActionResult> AddNewMovie(string MovieName, int MovieGenre, string MovieDescription, string Link, int UserId)
        {
            try
            {
                var existingMovies = await _dbContext.Movies
                    .FirstOrDefaultAsync(m => m.Link == Link && m.MovieName == MovieName);

                if (existingMovies != null)
                {
                    return BadRequest("This has already been submitted to the database.");
                }


                var aMovieGenre = await _dbContext.Genres.FindAsync(MovieGenre);
                var aUserId = await _dbContext.Users.FindAsync(UserId);

                if (aMovieGenre == null || aUserId == null)
                {
                    return BadRequest("This genre or user is invalid.");
                }

                var newMovie = new Movies
                {
                    MovieName = MovieName,
                    MovieGenre = MovieGenre,
                    MovieDescription = MovieDescription,
                    Link = Link,
                    UserId = UserId
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
