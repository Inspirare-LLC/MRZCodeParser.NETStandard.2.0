using MRZCodeParserNETStandard.Enums;
using MRZCodeParserNETStandard.Exceptions;
using MRZCodeParserNETStandard.Helpers;
using MRZCodeParserNETStandard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Parsers
{
    public abstract class MRZCodeParser
    {
        protected IEnumerable<string> RawLines { get; }

        public abstract CodeTypeEnum Type { get; }

        public abstract IEnumerable<MRZLine> Lines { get; }

        public IEnumerable<FieldTypeEnum> FieldTypes => Lines.SelectMany(x => x.FieldTypes);

        public string this[FieldTypeEnum type]
        {
            get
            {
                var fields = Fields;
                var targetType = ChangeBackwardFieldTypeToCurrent(type);

                if (fields.Fields.All(x => x.Type != targetType))
                    throw new MRZCodeException($"Code {Type} does not contain field {type}");

                return fields[targetType].Value;
            }
        }

        protected virtual FieldTypeEnum ChangeBackwardFieldTypeToCurrent(FieldTypeEnum type) => type;

        [Obsolete(message: "Will be changed to internal in next version")]
        public FieldsCollection Fields
        {
            get
            {
                var fields = new List<Field>();
                foreach (var line in Lines)
                {
                    fields.AddRange(line.Fields.Fields);
                }

                return new FieldsCollection(fields);
            }
        }

        protected MRZCodeParser(IEnumerable<string> lines)
        {
            RawLines = lines;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Lines.Select(x => x.Value));
        }

        public static MRZCodeParser Parse(string code)
        {
            var lines = new LineSplitter(code)
                .Split()
                .ToList();
            var type = new CodeTypeDetector(lines).DetectType();

            MRZCodeParser parser;
            switch (type)
            {
                case CodeTypeEnum.TD1:
                    parser = new TD1MRZCodeParser(lines);
                    break;
                case CodeTypeEnum.TD2:
                    parser = new TD2MRZCodeParser(lines);
                    break;
                case CodeTypeEnum.TD3:
                    parser = new TD3MRZCodeParser(lines);
                    break;
                case CodeTypeEnum.MRVA:
                    parser = new MRVAMRZCodeParser(lines);
                    break;
                case CodeTypeEnum.MRVB:
                    parser = new MRVBMRZCodeParser(lines);
                    break;
                default:
                    parser = new UnknownMRZCodeParser(lines);
                    break;
            }

            return parser;
        }
    }
}
