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

        [HttpGet("GetAllGenres")]
        public async Task<ActionResult<List<Genre>>> GetGenreByUserId()
        {
            var genre = await _dbContext.Genres
                .Select(g => new
                {
                    g.GenreId,
                    g.GenreTitle,
                    g.GenreDescription,

                })
                .ToListAsync();

            return Ok(genre);
        }
    }
}
