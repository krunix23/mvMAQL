using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace mv.MAQL
{
    class Logger : TextWriterTraceListener
    {
        public Logger(string logFile, string logName)
            : base(logFile, logName) { }

        public override void WriteLine(string message)
        {
            Console.WriteLine(message);
            Trace.Flush();
        }

        public override void WriteLine(string message, string category)
        {
            Console.WriteLine(message);
            Trace.Flush();
        }
    }
}
