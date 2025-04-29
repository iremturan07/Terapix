using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terapix.CORE.Models;
using Terapix.CORE.Repositories;

namespace Terapix.REPOSİTORY.Repositories
{
    public class SessionRepository(AppDbContext context):GenericRepository<Session>(context),ISessionRepository
    {
    }
}
