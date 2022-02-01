using Rentacar.Common.Exceptions;
using System;

namespace Rentacar.Common
{
    public class AssertionHelper
    {
        public static void AssertString(string param, string exceptionMessage = null)
        {
            if(string.IsNullOrEmpty(param))
            {
                throw new StringArgumentException(exceptionMessage ?? CommonExceptionMessages.StringArgumentNullOrEmpty);
            }
        }

        public static void AssertStringWhitespace(string param, string exceptionMessage = null)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new StringArgumentException(exceptionMessage ?? CommonExceptionMessages.StringArgumentNullOrEmpty);
            }
        }

        public static void AssertInt(int param, string exceptionMessage = null)
        {
            if(param <= 0)
            {
                throw new IntArgumentException(exceptionMessage ?? CommonExceptionMessages.IntegerNegative);
            }
        }

        public static void AssertObject(object param, string exceptionMessage = null)
        {
            if(param.IsNull())
            {
                throw new ArgumentNullException(exceptionMessage ?? CommonExceptionMessages.ObjectNull);
            }
        }
    }
}
