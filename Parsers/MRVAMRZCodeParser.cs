using MRZCodeParserNETStandard.Enums;
using MRZCodeParserNETStandard.Models;
using MRZCodeParserNETStandard.Models.CodeTypes;
using MRZCodeParserNETStandard.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Parsers
{
    internal class MRVAMRZCodeParser : MRZCodeParser
    {
        internal MRVAMRZCodeParser(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeTypeEnum Type => CodeTypeEnum.MRVA;

        public override IEnumerable<MRZLine> Lines => new MRZLine[]
        {
            new MRVAFirstLine(RawLines.First()),
            new MRVASecondLine(RawLines.Last())
        };

        protected override FieldTypeEnum ChangeBackwardFieldTypeToCurrent(FieldTypeEnum type)
        {
            FieldTypeEnum fType;

            switch (type)
            {
                case FieldTypeEnum.OptionalData2:
                    fType = FieldTypeEnum.OptionalData;
                    break;
                default:
                    fType = type;
                    break;
            }

            return fType;
        }
    }
}
