using Assignment3Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Data.Repositories.Contracts
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRoleWithUsers();
    }
}
