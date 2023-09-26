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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetRoleWithUsers()
        {
            return await _context.Roles.Include(x => x.Users).AsNoTracking().ToListAsync();
        }
    }
}
