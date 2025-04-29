using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.CORE.DTOs
{
    public class AppointmentDto:BaseDto
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly Hour { get; set; }
        public string PatientId { get; set; }
    }
}
