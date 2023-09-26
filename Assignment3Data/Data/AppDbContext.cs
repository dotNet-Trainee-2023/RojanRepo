using Assignment3Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Assignment3Data.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new List<Employee>
            {
                new Employee { Id = 1, Name = "Abhash", Department = "HR", Salary = 20000 },
                new Employee { Id = 2, Name = "Saksham", Department = "Operations", Salary = 30000 },
                new Employee { Id = 3, Name = "Anjish", Department = "R&D", Salary = 40000 }
            });

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

            Role r1 = new Role() { Id = 1, Title = "Admin" };
            Role r2 = new Role() { Id = 2, Title = "Normal" };

            modelBuilder.Entity<Role>().HasData(r1);
            modelBuilder.Entity<Role>().HasData(r2);

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Username = "nitesh", Email = "nitesh.shrestha@cotiviti.com", RoleId = 1 });

            modelBuilder.Entity<User>().HasData(new User { Id = 2, Username = "dipesh", Email = "dipesh@cotiviti.com", RoleId = 2 });

            modelBuilder.Entity<User>().HasData(new User { Id = 3, Username = "abhash", Email = "abhash@cotiviti.com", RoleId = 2 });

            modelBuilder.Entity<User>().HasData(new User { Id = 4, Username = "saksham", Email = "saksham@cotiviti.com", RoleId = 2 });
        }
    }
}
