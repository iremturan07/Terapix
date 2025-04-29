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
    public class PatientService(IGenericRepository<Patient> repository, IUnitOfWorks unitOfWorks, IPatientRepository patientRepository) : Service<Patient>(repository, unitOfWorks), IPatientService
    {
    }
}
