using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.Commons.Entities
{
    public abstract class AbstractPatient : AbstractUser
    {
        public List<Messages> Messages { get; set; }
        public List<MedicalProcedures> MedicalAppointments { get; set; }
    }
}
