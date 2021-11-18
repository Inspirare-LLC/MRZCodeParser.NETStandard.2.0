using MRZCodeParserNETStandard.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZCodeParserNETStandard.Helpers
{
    internal class CodeTypeDetector
    {
        private readonly IEnumerable<string> lines;

        internal CodeTypeDetector(IEnumerable<string> lines)
        {
            this.lines = lines;
        }

        internal CodeTypeEnum DetectType()
        {
            CodeTypeEnum type = lines.Count() == 3 && lines.First().Length == 30
                ? CodeTypeEnum.TD1
                : lines.First().Length == 44 && lines.Count() == 2
                    ? lines.First()[0] == 'P'
                        ? CodeTypeEnum.TD3
                        : CodeTypeEnum.MRVA
                    : lines.First().Length == 36 && lines.Count() == 2
                        ? lines.First()[0] == 'V'
                            ? CodeTypeEnum.MRVB
                            : CodeTypeEnum.TD2
                        : CodeTypeEnum.UNKNOWN;

            return type;
        }
    }
}
