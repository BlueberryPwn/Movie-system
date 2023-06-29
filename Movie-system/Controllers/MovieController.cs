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
        private readonly MovieContext _dbContext;
        public MovieController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Gets all movies that exists in the database
        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }
            return await _dbContext.Movies.ToListAsync();
        }

        // GET: Gets a specific movie that exists in the database by typing in a specific id
        [HttpGet("GetMovieById")]
        public async Task <ActionResult<Movie>> GetMovie(int id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: Adds a movie to the database
        [HttpPost("AddMovie")]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieId }, movie);
        }

        // PUT: Replaces a movie that exists in the database with another movie
        [HttpPut("ReplaceMovie")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            _dbContext.Entry(movie).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: Deletes a movie from the database
        [HttpDelete("DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(long id)
        {
            return (_dbContext.Movies?.Any(e => e.MovieId  == id)).GetValueOrDefault();
        }
    }
}
