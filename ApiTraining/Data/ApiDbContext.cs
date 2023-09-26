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
    }
}
