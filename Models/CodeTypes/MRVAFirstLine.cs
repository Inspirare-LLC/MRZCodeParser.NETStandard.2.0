using MRZCodeParserNETStandard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Models.CodeTypes
{
    internal class MRVAFirstLine : MRZLine
    {
        internal MRVAFirstLine(string value) : base(value)
        {
        }

        protected override string Pattern => "(V[A-Z0-9<]{1})([A-Z]{3})([A-Z0-9<]{39})";

        internal override IEnumerable<FieldTypeEnum> FieldTypes => new[]
        {
            FieldTypeEnum.DocumentType,
            FieldTypeEnum.CountryCode,
            FieldTypeEnum.PrimaryIdentifier,
        };
    }
}
