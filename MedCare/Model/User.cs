using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public SecureString Password { get; set; }
    }
}
