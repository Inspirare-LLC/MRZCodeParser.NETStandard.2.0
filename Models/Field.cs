using MRZCodeParserNETStandard.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRZCodeParserNETStandard.Models
{
    public class Field
    {
        public FieldTypeEnum Type { get; }
        public string Value { get; }

        public Field(FieldTypeEnum type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
