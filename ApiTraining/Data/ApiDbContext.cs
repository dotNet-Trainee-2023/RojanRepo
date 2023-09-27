using ApiTraining.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiTraining.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //for seeding
            var placeList = new List<Place>()
             {
            new Place()
            {
                Id = Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                Name = "Bishnudwar",
                Location = "Shivapuri"
            }
            };

            //seed to db
            modelBuilder.Entity<Place>().HasData(placeList);

        }
    }
}
