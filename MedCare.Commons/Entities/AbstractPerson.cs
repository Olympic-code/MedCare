using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Commons.entities
{
    public abstract class AbstractPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Cpf { get; set; }
    }
}
