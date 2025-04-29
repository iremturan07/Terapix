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
    public class AppointmentService(IGenericRepository<Appointment> repository,IUnitOfWorks unitOfWorks, IAppointmentRepository appointmentRepository): Service<Appointment>(repository, unitOfWorks), IAppointmentService
    {

    }
    
    
}
