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
        public DbSet<Genres> Genres { get; set; } = null!;
        public DbSet<LikedGenres> LikedGenres { get; set; } = null!;
        public DbSet<Movies> Movies { get; set; } = null!;
        public DbSet<Reviews> Reviews { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ASPIRE;Initial Catalog=MovieSystemDB;Integrated Security=True;");
            }
        }
    }
}
