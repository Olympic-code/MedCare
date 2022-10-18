using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Commons.entities
{
    public abstract class AbstractPatient : AbstractUser
    {
        public List<Messages> Messages { get; set; }
        public List<MedicalProcedures> MedicalAppointments { get; set; }
    }
}
