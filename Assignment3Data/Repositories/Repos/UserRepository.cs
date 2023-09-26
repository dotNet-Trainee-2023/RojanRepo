using Assignment3Data.Data;
using Assignment3Data.Repositories.Contracts;
using Assignment3Model.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Data.Repositories.Repos
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersWithRole()
        {
            
            return await _context.Users
                .Include(x => x.UserRole)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
