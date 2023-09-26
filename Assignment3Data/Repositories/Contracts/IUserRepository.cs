using Assignment3Model.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Data.Repositories.Contracts
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<List<User>> GetAllUsersWithRole();
    }
}
