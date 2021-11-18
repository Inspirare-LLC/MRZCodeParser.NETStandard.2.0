using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Helpers
{
    internal class LineSplitter
    {
        private readonly string input;

        internal LineSplitter(string input)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
        }

        internal IEnumerable<string> Split()
        {
            var separator = input.Contains("\r\n") ? "\r\n" : "\n";
            return input.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
