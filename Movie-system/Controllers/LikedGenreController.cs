using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_system.Models;

namespace Movie_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedGenreController : ControllerBase
    {
        private readonly MovieSystemContext _dbContext;
        public LikedGenreController(MovieSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetLikedGenresByUserId/{LikedByUserId}")]
        public async Task<ActionResult<List<LikedGenre>>> GetLikedGenresByLikedByUserId(int LikedByUserId)
        {
            var genre = await _dbContext.LikedGenres
                            .Where(lg => lg.LikedByUserId == LikedByUserId)
                            .Select(lg => lg.GenreId)
                            .ToListAsync();

            return Ok(genre);
        }

        [HttpPost("AddLikedGenre/{LikedByUserId}/{GenreId}")]
        public async Task<IActionResult> AddLikedGenre(int LikedByUserId, int GenreId)
        {
            try
            {
                var existingLikedGenre = await _dbContext.LikedGenres
                    .FirstOrDefaultAsync(lg => lg.LikedByUserId == LikedByUserId && lg.GenreId == GenreId);

                if (existingLikedGenre != null)
                {
                    return BadRequest("This LikedGenre already exists for this user and genre.");
                }

                var user = await _dbContext.Users.FindAsync(LikedByUserId);
                var genre = await _dbContext.Genres.FindAsync(GenreId);

                if (user == null || genre == null)
                {
                    return BadRequest("This user or genre is invalid.");
                }

                var newLikedGenre = new LikedGenre
                {
                    LikedByUserId = LikedByUserId,
                    GenreId = GenreId
                };

                _dbContext.LikedGenres.Add(newLikedGenre);
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
