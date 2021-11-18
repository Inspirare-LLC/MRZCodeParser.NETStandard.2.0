using MRZCodeParserNETStandard.Enums;
using MRZCodeParserNETStandard.Exceptions;
using MRZCodeParserNETStandard.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MRZCodeParserNETStandard.Models
{
    public abstract class MRZLine
    {
        public string Value { get; }

        public int Length => Value?.Length ?? 0;

        public FieldsCollection Fields
        {
            get
            {
                var regex = new Regex(Pattern);
                var match = regex.Match(Value);

                if (!match.Success)
                    throw new MRZCodeException($"Line: {Value} does not match to pattern: {Pattern}");

                var fields = new List<Field>();
                for (var i = 0; i < FieldTypes.Count(); i++)
                {
                    fields.Add(new Field(FieldTypes.ElementAt(i),
                                         new ValueCleaner(match.Groups[i + 1].Value).Clean()));
                }

                return new FieldsCollection(fields);
            }
        }

        protected abstract string Pattern { get; }

        internal abstract IEnumerable<FieldTypeEnum> FieldTypes { get; }

        internal MRZLine(string value)
        {
            Value = value;
        }
    }
}
