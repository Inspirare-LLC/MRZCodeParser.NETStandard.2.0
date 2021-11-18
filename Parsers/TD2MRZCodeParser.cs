using MRZCodeParserNETStandard.Enums;
using MRZCodeParserNETStandard.Models;
using MRZCodeParserNETStandard.Models.CodeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Parsers
{
    internal class TD2MRZCodeParser : MRZCodeParser
    {
        internal TD2MRZCodeParser(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeTypeEnum Type => CodeTypeEnum.TD2;

        public override IEnumerable<MRZLine> Lines => new MRZLine[]
        {
            new TD2FirstLine(RawLines.First()),
            new TD2SecondLine(RawLines.Last())
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
