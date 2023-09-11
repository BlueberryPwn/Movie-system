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


    }
}
