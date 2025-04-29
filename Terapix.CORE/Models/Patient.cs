using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.CORE.Models
{
    public class Patient:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Eposta { get; set; }
        public string Illness { get; set; }
        public int Age { get; set; }
        public string Allergy { get; set; }
    }
}
