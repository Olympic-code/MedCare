﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException (string message) : base(message)
        {
           
        }
    }
}
