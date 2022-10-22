using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace MedCare.Commons.Entities
{
    public abstract class AbstractUser : AbstractPerson
    {
        public string Email { get; set; }
        public String Password { get; set; }
    }
}
