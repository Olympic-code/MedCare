using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.Commons.Entities
{
    public class MedicalProcedures
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EnumPriority Priority { get; set; }
        public EnumProcedureType Type { get; set; }
    }
}
