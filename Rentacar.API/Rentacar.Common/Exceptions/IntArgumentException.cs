using System;

namespace Rentacar.Common.Exceptions
{
    public class IntArgumentException : ArgumentException
    {
        public IntArgumentException()
        {
        }

        public IntArgumentException(string message)
            : base(message)
        {
        }

        public IntArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
