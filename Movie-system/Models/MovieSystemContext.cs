using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Movie_system.Migrations;

namespace Movie_system.Models
{
    public class MovieSystemContext : DbContext
    {
        public MovieSystemContext(DbContextOptions<MovieSystemContext> options)
            : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ASPIRE;Initial Catalog=MovieSystemDB;Integrated Security=True;");
            }
        }
    }
}
