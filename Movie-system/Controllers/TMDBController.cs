using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_system.Models;

namespace Movie_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDBController : ControllerBase
    {
        private readonly MovieSystemContext _dbContext;
        public TMDBController(MovieSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("TMDBDiscover/{TmdbId}")]
        public async Task<ActionResult> TMDBDiscover(int TmdbId)
        {
            var TmdbUrl = $" https://api.themoviedb.org/3/discover/movie?api_key=6515a73f1ebd8a6b92919c33fab29510&with_genres={TmdbId}";

            HttpClient client = new HttpClient(); // Sends a HTTP request to TMDB
            HttpResponseMessage response = await client.GetAsync(TmdbUrl); // Awaits an answer from TMDB
            response.EnsureSuccessStatusCode(); // Throws an exception if the response is not successful
            string responseBody = await response.Content.ReadAsStringAsync();

            return Ok(responseBody);
        }
    }
}
