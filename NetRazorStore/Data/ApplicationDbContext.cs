using Microsoft.EntityFrameworkCore;
using NetRazorStore.Models;

namespace NetRazorStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // create Categories table
        public DbSet<Category> Categories { get; set; }

        // seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fruit", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Vegetables", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Grains", DisplayOrder = 3 }
                );
        }
    }
}

    
