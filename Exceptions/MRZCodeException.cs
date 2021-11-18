using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Exceptions
{
    public class MRZCodeException : Exception
    {
        internal MRZCodeException(string message) : base(message)
        {
        }
    }
}
