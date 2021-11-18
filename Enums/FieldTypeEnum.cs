using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Enums
{
    public enum FieldTypeEnum
    {
        DocumentType,
        CountryCode,
        DocumentNumber,
        DocumentNumberCheckDigit,
        OptionalData1,
        BirthDate,
        BirthDateCheckDigit,
        Sex,
        ExpiryDate,
        ExpiryDateCheckDigit,
        Nationality,
        OptionalData2,
        [Obsolete("Use OptionalDataCheckDigit. Will be removed in next version")]
        OptionalData2CheckDigit,
        Names,
        OverallCheckDigit,
        PrimaryIdentifier,
        OptionalData,
        OptionalDataCheckDigit
    }
}
