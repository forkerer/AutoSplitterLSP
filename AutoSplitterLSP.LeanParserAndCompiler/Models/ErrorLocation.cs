using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSplitterLSP.LeanParserAndCompiler.Models
{
    public class ErrorLocation
    {
        public int Position { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public string Message { get; set; }
    }
}
