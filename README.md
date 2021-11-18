# MRZCodeParser.NETStandard.2.0
MRZ Code parser for NET.Standard 2.0. Code taken and adopted from https://github.com/snifter/MRZCode.NET

# Nuget package
Available as nuget package at https://www.nuget.org/packages/MRZCodeParserNETStandard/

# Usage

To extract data from MRZ firstly it has to be OCR'd, only then it can be passed into this parser.

To parse an MRZ string, use it like this `var parsed = MRZCodeParser.Parse(mrzCodeString);`.

After that, parsed fields can be accessed on the created object `parsed.Lines`, type of the document can be retrieved from `parsed.Type`, raw string lines can be accessed from `parsed.RawLines` and all field types that were passed are stored in `parsed.FieldTypes` property.

# Contributions

Any contributions are welcome in the form of pull requests.

# Issues

Issues can be raised in the `Issue` section where I'll try to address all of them.
