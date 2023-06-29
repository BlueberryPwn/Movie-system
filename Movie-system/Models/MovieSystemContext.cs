using Microsoft.EntityFrameworkCore;

namespace Movie_system.Models
{
    public class MovieSystemContext : DbContext
    {
        public MovieSystemContext(DbContextOptions<MovieSystemContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; } = null!;
    }
}
