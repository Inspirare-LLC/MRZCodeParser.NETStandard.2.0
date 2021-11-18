using MRZCodeParserNETStandard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Models.CodeTypes
{
    internal class TD2SecondLine : MRZLine
    {
        internal TD2SecondLine(string value) : base(value)
        {
        }

        protected override string Pattern =>
            "([A-Z0-9<]{9})([0-9]{1})([A-Z<]{3})([0-9]{6})([0-9]{1})([M|F|X|<]{1})([0-9]{6})([0-9]{1})([A-Z0-9<]{7})([0-9]{1})";

        internal override IEnumerable<FieldTypeEnum> FieldTypes => new[]
        {
            FieldTypeEnum.DocumentNumber,
            FieldTypeEnum.DocumentNumberCheckDigit,
            FieldTypeEnum.Nationality,
            FieldTypeEnum.BirthDate,
            FieldTypeEnum.BirthDateCheckDigit,
            FieldTypeEnum.Sex,
            FieldTypeEnum.ExpiryDate,
            FieldTypeEnum.ExpiryDateCheckDigit,
            FieldTypeEnum.OptionalData,
            FieldTypeEnum.OverallCheckDigit
        };
    }
}
