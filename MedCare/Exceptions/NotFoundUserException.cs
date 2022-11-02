using System;

namespace MedCare.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException(string message) : base(message)
        {

        }
    }
}
