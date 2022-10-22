using System;
using System.Collections.Generic;
using System.Text;

namespace MedCare.Commons.Entities
{
    public abstract class AbstractProfessional : AbstractUser
    {
        public string ProfessionalRegister { get; set; }
        public string ProfessionalType { get; set; }
        public List<MedicalProcedures> MedicalAppointments { get; set; }
        public List<Messages> Messages { get; set; }
    }
}
