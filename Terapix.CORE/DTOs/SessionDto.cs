using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.CORE.DTOs
{
    public class SessionDto:BaseDto
    {
        public string Result { get; set; }
        public string Test { get; set; }
        public string Treatment { get; set; }
        public string AppliedTherapy { get; set; }
        public string Progres { get; set; }
        public DateOnly NextSession { get; set; }
    }
}
