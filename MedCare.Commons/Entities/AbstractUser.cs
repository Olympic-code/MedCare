﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Commons.Entities
{
    public abstract class AbstractUser : AbstractPerson
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}