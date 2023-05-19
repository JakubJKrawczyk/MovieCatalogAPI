using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MovieCatalog___Practice_Quest.Models;

namespace MovieCatalog___Practice_Quest.Database
{
    public class AppDbContext : DbContext
    {

        public DbSet<Movie> Movies { get; private set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}
