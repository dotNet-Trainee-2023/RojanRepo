using Assignment3Data.Data;
using Assignment3Data.Repositories.Contracts;
using Assignment3Data.Repositories.Repos;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepository Products { get; set; }
        public IUserRepository Users { get; set; }
        public IRoleRepository Roles { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(context);
            Users = new UserRepository(context);
            Roles = new RoleRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
