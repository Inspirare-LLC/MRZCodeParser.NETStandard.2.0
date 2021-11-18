using MRZCodeParserNETStandard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Models.CodeTypes
{
    internal class TD1ThirdLine : MRZLine
    {
        public TD1ThirdLine(string value) : base(value)
        {
        }

        protected override string Pattern => "([A-Z0-9<]{30})";

        internal override IEnumerable<FieldTypeEnum> FieldTypes => new[] { FieldTypeEnum.Names };
    }
}
