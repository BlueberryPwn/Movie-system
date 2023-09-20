using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Movie_system.Migrations;

namespace Movie_system.Models
{
    public partial class MovieSystemContext : DbContext
    {
        public MovieSystemContext()
        {

        }

        public MovieSystemContext(DbContextOptions<MovieSystemContext> options)
            : base(options)
        {

        }
        public DbSet<Genres> Genres { get; set; } = null!;
        public DbSet<LikedGenres> LikedGenres { get; set; } = null!;
        public DbSet<Movies> Movies { get; set; } = null!;
        public DbSet<Reviews> Reviews { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.GenreId); // Makes sure that this entity along with all other entities have keys
            });

            modelBuilder.Entity<LikedGenres>(entity =>
            {
                entity.HasKey(e => e.LikedGenreId);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
