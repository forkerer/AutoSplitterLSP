using AutoSplitterLSP.LeanParserAndCompiler.ASL;
using AutoSplitterLSP.LeanParserAndCompiler.Exceptions;

namespace AutoSplitterLSP.Core
{
    public class LSPProvider
    {
        public LSPProvider()
        {
        }

        void ProcessFile(string content)
        {
            ASLScript parsedScript = null;
            try
            {
                parsedScript = ASLParser.Parse(content);
            }
            catch (ASLParseException parseException)
            {
                foreach(var error in parseException.Errors)
                    System.Console.WriteLine();
            }
        }
    }
}
