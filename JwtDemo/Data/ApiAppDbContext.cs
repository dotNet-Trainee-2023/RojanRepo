using JwtDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace JwtDemo.Data
{
    public class ApiAppDbContext:DbContext
    {
        public ApiAppDbContext(DbContextOptions<ApiAppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
