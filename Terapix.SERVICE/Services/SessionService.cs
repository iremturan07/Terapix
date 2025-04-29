using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terapix.CORE.Models;
using Terapix.CORE.Repositories;
using Terapix.CORE.Services;
using Terapix.CORE.UnitOfWorks;

namespace Terapix.SERVICE.Services
{
    public class SessionService(IGenericRepository<Session> repository, IUnitOfWorks unitOfWorks, ISessionRepository sessionRepository) : Service<Session>(repository, unitOfWorks), ISessionService
    {
    }
}
