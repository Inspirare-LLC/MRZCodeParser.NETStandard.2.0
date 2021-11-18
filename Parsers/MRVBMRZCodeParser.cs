using MRZCodeParserNETStandard.Enums;
using MRZCodeParserNETStandard.Models;
using MRZCodeParserNETStandard.Models.CodeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Parsers
{
    internal class MRVBMRZCodeParser : MRZCodeParser
    {
        internal MRVBMRZCodeParser(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeTypeEnum Type => CodeTypeEnum.MRVB;

        public override IEnumerable<MRZLine> Lines => new MRZLine[]
        {
            new MRVBFirstLine(RawLines.First()),
            new MRVBSecondLine(RawLines.Last())
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
