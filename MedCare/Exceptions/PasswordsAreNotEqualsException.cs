using System;

namespace MedCare.Exceptions
{
    public class PasswordsAreNotEqualsException : Exception
    {
        public PasswordsAreNotEqualsException(string message) : base(message)
        {

        }
    }
}
