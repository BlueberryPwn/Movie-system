using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_system.Models;

namespace Movie_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MovieSystemContext _dbContext;
        public UserController(MovieSystemContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }

        [HttpGet("GetUserById/{UserId}")]
        public async Task<ActionResult<List<Users>>> GetUserById(int UserId)
        {
            var user = await _dbContext.Users
                .Where(u =>  u.UserId == UserId)
                .Select(u => new
                {
                    u.UserId,
                    u.UserName,
                    u.EmailAddress
                })
                .ToListAsync();

            return Ok(user);
        }
    }
}
