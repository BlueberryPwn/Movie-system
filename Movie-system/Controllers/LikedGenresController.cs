using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_system.Models;

namespace Movie_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedGenresController : ControllerBase
    {
        private readonly MovieSystemContext _dbContext;
        public LikedGenresController(MovieSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetLikedGenresByUserId/{UserId}")]
        public async Task<ActionResult<List<LikedGenres>>> GetLikedGenresByUserId(int UserId)
        {
            var genres = await _dbContext.LikedGenres
                            .Where(lg => lg.UserId == UserId)
                            .Select(lg => lg.GenreId)
                            .ToListAsync();

            return Ok(genres);
        }

        [HttpPost("AddLikedGenre/{UserId}/{GenreId}")]
        public async Task<IActionResult> AddLikedGenre(int UserId, int GenreId)
        {
            try
            {
                var existingLikedGenre = await _dbContext.LikedGenres
                    .FirstOrDefaultAsync(lg => lg.UserId == UserId && lg.GenreId == GenreId);

                if (existingLikedGenre != null)
                {
                    return BadRequest("This LikedGenre already exists for this user and genre.");
                }

                var user = await _dbContext.Users.FindAsync(UserId);
                var genre = await _dbContext.Genres.FindAsync(GenreId);

                if (user == null || genre == null)
                {
                    return BadRequest("This user or genre is invalid.");
                }

                var newLikedGenres = new LikedGenres
                {
                    UserId = UserId,
                    GenreId = GenreId
                };

                _dbContext.LikedGenres.Add(newLikedGenres);
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
