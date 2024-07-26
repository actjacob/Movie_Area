using Microsoft.EntityFrameworkCore;
using Movie_Area.Entities;

namespace Movie_Area.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category>  Categories   { get; set; }
        public DbSet<Movie>  Movies  { get; set; }
    }
}
