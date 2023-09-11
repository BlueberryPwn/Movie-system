using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_system.Models;

namespace Movie_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MovieSystemContext _dbContext;
        public GenresController(MovieSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllGenres")]
        public async Task<ActionResult<List<Genres>>> GetAllGenres()
        {
            var genres = await _dbContext.Genres
                .Select(g => new
                {
                    g.GenreId,
                    g.GenreName,
                    g.GenreDescription,

                })
                .ToListAsync();

            return Ok(genres);
        }
    }
}
