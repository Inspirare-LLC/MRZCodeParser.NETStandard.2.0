using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Helpers
{
    internal class ValueCleaner
    {
        private readonly string value;

        internal ValueCleaner(string value)
        {
            this.value = value;
        }

        internal string Clean()
        {
            return value.TrimEnd('<')
                .Replace("<<", ", ")
                .Replace("<", " ");
        }
    }
}
