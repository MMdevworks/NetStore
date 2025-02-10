using Microsoft.EntityFrameworkCore;
using NetStore.Models;


namespace NetStore.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
             
        }
        // create Categories table
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fruit", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Vegetables", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Grains", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    ProductName = "Apple", 
                    Description = "Red Delicious", 
                    Brand = "Organic Farms", 
                    ListPrice = 1.50, 
                    Price = 1.00, 
                    Price2 = .75, 
                    Price3 = .50,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Orange",
                    Description = "Tangy Sweet",
                    Brand = "Organic Farms",
                    ListPrice = 1.25,
                    Price = 1.00,
                    Price2 = .75,
                    Price3 = .50,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Bell Pepper",
                    Description = "Yellow crisp",
                    Brand = "Organic Farms",
                    ListPrice = 1.00,
                    Price = 1.00,
                    Price2 = .75,
                    Price3 = .50,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Oatmeal",
                    Description = "Chewy whole grain",
                    Brand = "The RedMill",
                    ListPrice = 1.00,
                    Price = 1.00,
                    Price2 = .75,
                    Price3 = .50,
                    CategoryId = 3,
                    ImageUrl = ""
                }
                );
        }
    }
}
