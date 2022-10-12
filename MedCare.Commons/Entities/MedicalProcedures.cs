using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Commons.entities
{
    public class MedicalProcedures
    {
        public int ID { get; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EnumPriority Priority { get; set; }
        public EnumProcedureType Type { get; set; }

    }
}
