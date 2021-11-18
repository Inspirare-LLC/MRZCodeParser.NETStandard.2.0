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
            CodeTypeEnum type;

            if (lines.Count() == 3 && lines.First().StartsWith("ID"))
                type = CodeTypeEnum.TD1;
            else if (lines.Count() == 2 && lines.First().StartsWith("ID"))
                type = CodeTypeEnum.TD2;
            else if (lines.Count() == 2 && lines.First()[0] == 'P')
                type = CodeTypeEnum.TD3;
            else if (lines.Count() == 2 && lines.First()[0] == 'V' && lines.First().Length == 44)
                type = CodeTypeEnum.MRVA;
            else if (lines.Count() == 2 && lines.First()[0] == 'V' && lines.First().Length == 36)
                type = CodeTypeEnum.MRVB;
            else
                type = CodeTypeEnum.UNKNOWN;

            return type;
        }
    }
}
