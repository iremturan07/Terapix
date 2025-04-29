using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.CORE.Models
{
    public class Appointment:BaseEntity
    {
        public DateTime Date {  get; set; }
        public TimeOnly Hour { get; set; }
        public string Comment { get; set; }
        public string PatientId { get; set; }

    }
}
