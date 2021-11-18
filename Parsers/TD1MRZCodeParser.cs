using MRZCodeParserNETStandard.Enums;
using MRZCodeParserNETStandard.Models;
using MRZCodeParserNETStandard.Models.CodeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Parsers
{
    internal class TD1MRZCodeParser : MRZCodeParser
    {
        internal TD1MRZCodeParser(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeTypeEnum Type => CodeTypeEnum.TD1;

        public override IEnumerable<MRZLine> Lines => new MRZLine[]
        {
            new TD1FirstLine(RawLines.First()),
            new TD1SecondLine(RawLines.ElementAt(1)),
            new TD1ThirdLine(RawLines.Last())
        };
    }
}
