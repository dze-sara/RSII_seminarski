using System;

namespace Rentacar.Common.Exceptions
{
    public class StringArgumentException : ArgumentException
    {
        public StringArgumentException()
        {
        }

        public StringArgumentException(string message)
            : base(message)
        {
        }

        public StringArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
