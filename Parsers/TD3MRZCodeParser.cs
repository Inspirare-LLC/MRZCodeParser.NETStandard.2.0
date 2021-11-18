using MRZCodeParserNETStandard.Enums;
using MRZCodeParserNETStandard.Models;
using MRZCodeParserNETStandard.Models.CodeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Parsers
{
    internal class TD3MRZCodeParser : MRZCodeParser
    {
        internal TD3MRZCodeParser(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeTypeEnum Type => CodeTypeEnum.TD3;

        public override IEnumerable<MRZLine> Lines => new MRZLine[]
        {
            new TD3FirstLine(RawLines.First()),
            new TD3SecondLine(RawLines.Last())
        };

        protected override FieldTypeEnum ChangeBackwardFieldTypeToCurrent(FieldTypeEnum type)
        {
            FieldTypeEnum fType;

            switch (type)
            {
                case FieldTypeEnum.OptionalData2:
                    fType = FieldTypeEnum.OptionalData;
                    break;
                case FieldTypeEnum.OptionalData2CheckDigit:
                    fType = FieldTypeEnum.OptionalDataCheckDigit;
                    break;
                default:
                    fType = type;
                    break;
            }

            return fType;
        }
    }
}
