using System.Collections.Generic;

namespace MedCare.Commons.Entities
{
    public abstract class AbstractProfessional : AbstractUser
    {
        public string ProfessionalRegister { get; set; }
        public string ProfessionalType { get; set; }
        public List<MedicalProcedures> MedicalProcedures { get; set; }
        public List<Messages> Messages { get; set; }
    }
}
