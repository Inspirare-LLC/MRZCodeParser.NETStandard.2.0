using MRZCodeParserNETStandard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Models.CodeTypes
{
    internal class UnknownLine : MRZLine
    {
        internal UnknownLine(string value) : base(value)
        {
        }

        protected override string Pattern => "";

        internal override IEnumerable<FieldTypeEnum> FieldTypes => new FieldTypeEnum[0];
    }
}
