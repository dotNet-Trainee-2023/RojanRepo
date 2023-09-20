using Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new List<Category>
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
            });
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product { Id = 1, Name = "Iphone15", Price = 250000, CategoryId = 1},
                new Product { Id = 2, Name = "Jeans" , Price = 3000, CategoryId = 2},
            });
        }
    }
}
