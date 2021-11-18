using MRZCodeParserNETStandard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Models
{
    public class FieldsCollection
    {
        public IEnumerable<Field> Fields { get; }

        internal FieldsCollection(IEnumerable<Field> fields)
        {
            Fields = fields;
        }

        public Field this[FieldTypeEnum type] => Fields.Single(x => x.Type == type);
    }
}
