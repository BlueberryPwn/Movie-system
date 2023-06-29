using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_system.Models;

namespace Movie_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly MovieSystemContext _dbContext;
        public GenreController(MovieSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Gets all genres that exist in the database
        [HttpGet("GetAllGenres")]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            if (_dbContext.Genres == null)
            {
                return NotFound();
            }
            return await _dbContext.Genres.ToListAsync();
        }

        // GET: Get all genres that are connected to a specific user
        [HttpGet("GetGenreById")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            if (_dbContext.Genres == null)
            {
                return NotFound();
            }
            var genre = await _dbContext.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }
    }
}
