using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.CORE.DTOs
{
    public class PatientDto:BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Illness { get; set; }
        public int Age { get; set; }
        public string Allergy { get; set; }
        public string Address { get; set; }
        public string Eposta { get; set; }
    }
}
