using MRZCodeParserNETStandard.Enums;
using MRZCodeParserNETStandard.Models;
using MRZCodeParserNETStandard.Models.CodeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Parsers
{
    internal class UnknownMRZCodeParser : MRZCodeParser
    {
        internal UnknownMRZCodeParser(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeTypeEnum Type => CodeTypeEnum.UNKNOWN;

        public override IEnumerable<MRZLine> Lines => RawLines.Select(x => new UnknownLine(x));
    }
}
