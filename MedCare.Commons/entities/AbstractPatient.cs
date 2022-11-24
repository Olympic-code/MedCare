using System.Collections.Generic;

namespace MedCare.Commons.Entities
{
    public abstract class AbstractPatient : AbstractUser
    {
        public List<Messages> Messages { get; set; }
        public List<MedicalProcedures> MedicalProcedures { get; set; }
    }
}
