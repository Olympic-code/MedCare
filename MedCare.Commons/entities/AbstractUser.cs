using System;

namespace MedCare.Commons.Entities
{
    public abstract class AbstractUser : AbstractPerson
    {
        public string Email { get; set; }
        public String Password { get; set; }
    }
}
