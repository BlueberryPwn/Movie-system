using Microsoft.EntityFrameworkCore;

namespace Movie_system.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }
        DbSet<Movie> Movies { get; set; } = null!;
    }
}
