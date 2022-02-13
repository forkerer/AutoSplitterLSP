using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSplit.LeanCore.Options
{
    public static class Log
    {
        static Log()
        {
            //try
            //{
            //    if (!EventLog.SourceExists("LiveSplit"))
            //        EventLog.CreateEventSource("LiveSplit", "Application");
            //}
            //catch { }

            //try
            //{
            //    var listener = new EventLogTraceListener("LiveSplit");
            //    listener.Filter = new EventTypeFilter(SourceLevels.Warning);
            //    Trace.Listeners.Add(listener);
            //}
            //catch { }
        }

        public static void Error(Exception ex)
        {
            try
            {
                //Trace.TraceError("{0}\n\n{1}", ex.Message, ex.StackTrace);
                Console.WriteLine(ex.ToString());
            }
            catch { }
        }

        public static void Error(string message)
        {
            try
            {
                //Trace.TraceError(message);
                Console.WriteLine(message);
            }
            catch { }
        }

        public static void Info(string message)
        {
            try
            {
                //Trace.TraceInformation(message);
                Console.WriteLine(message);
            }
            catch { }
        }

        public static void Warning(string message)
        {
            try
            {
                //Trace.TraceWarning(message);
                Console.WriteLine(message);
            }
            catch { }
        }
    }
}
