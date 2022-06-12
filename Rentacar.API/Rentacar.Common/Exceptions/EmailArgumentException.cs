using System;

namespace Rentacar.Common.Exceptions
{
    public class EmailArgumentException : ArgumentException
    {
        public EmailArgumentException()
        {
        }

        public EmailArgumentException(string message)
            : base(message)
        {
        }

        public EmailArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
