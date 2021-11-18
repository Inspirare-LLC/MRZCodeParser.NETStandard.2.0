using MRZCodeParserNETStandard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Models.CodeTypes
{
    internal class TD1SecondLine : MRZLine
    {
        internal TD1SecondLine(string value) : base(value)
        {
        }

        protected override string Pattern =>
            "([0-9]{6})([0-9]{1})([M|F|X|<]{1})([0-9]{6})([0-9]{1})([A-Z<]{3})([A-Z0-9<]{11})([0-9]{1})";

        internal override IEnumerable<FieldTypeEnum> FieldTypes => new[]
        {
            FieldTypeEnum.BirthDate,
            FieldTypeEnum.BirthDateCheckDigit,
            FieldTypeEnum.Sex,
            FieldTypeEnum.ExpiryDate,
            FieldTypeEnum.ExpiryDateCheckDigit,
            FieldTypeEnum.Nationality,
            FieldTypeEnum.OptionalData2,
            FieldTypeEnum.OverallCheckDigit
        };
    }
}
