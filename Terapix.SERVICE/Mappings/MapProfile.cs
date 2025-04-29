using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Terapix.CORE.DTOs;
using Terapix.CORE.Models;

namespace Terapix.SERVICE.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Medication, MedicationDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Session, SessionDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
