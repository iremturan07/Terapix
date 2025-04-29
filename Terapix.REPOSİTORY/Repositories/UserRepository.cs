using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terapix.CORE.Models;
using Terapix.CORE.Repositories;

namespace Terapix.REPOSİTORY.Repositories
{
    public class UserRepository(AppDbContext context): GenericRepository<User>(context),IUserRepository
    {
    }
}
