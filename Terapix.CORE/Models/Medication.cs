﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.CORE.Models
{
    public class Medication:BaseEntity
    {
        public Medication()
        {
            Status = true; 
        }
        public string Medicine { get; set; }
        public double Dosage { get; set; }
        public DateOnly Start {  get; set; }
        public DateOnly End { get; set; }
        public string Reason { get; set; }
        public string DosageUnit { get; set; }
        public bool Status { get; set; }

    }
}
