using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MovieCatalog___Practice_Quest.Models;

namespace MovieCatalog___Practice_Quest.Database
{
    public class AppDbContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MovieCatalog");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

           

        }
    }
}
