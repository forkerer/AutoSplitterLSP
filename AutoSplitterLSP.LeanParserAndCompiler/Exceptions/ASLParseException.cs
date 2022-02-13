using AutoSplitterLSP.LeanParserAndCompiler.Models;
using System;
using System.Collections.Generic;

namespace AutoSplitterLSP.LeanParserAndCompiler.Exceptions
{
    public class ASLParseException : Exception
    {
        public IEnumerable<ErrorLocation> Errors { get; set; }
        public ASLParseException(IEnumerable<ErrorLocation> errors)
        {
            Errors = errors;
        }
    }
}
