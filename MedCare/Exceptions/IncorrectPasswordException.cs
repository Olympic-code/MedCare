using System;

namespace MedCare.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public IncorrectPasswordException(string message) : base(message)
        {

        }
    }
}
