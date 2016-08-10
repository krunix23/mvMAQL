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
            message += "\n";
            Console.WriteLine(message);
            Trace.Flush();
        }

        public override void WriteLine(string message, string category)
        {
            //switch (category.ToLower())
            //{
            //    case "info":
            //        output_.SelectionColor = Color.DarkGreen;
            //        break;
            //    case "warning":
            //        output_.SelectionColor = Color.Orange;
            //        break;
            //    case "error":
            //        output_.SelectionColor = Color.Red;
            //        break;
            //    default:
            //        output_.SelectionColor = Color.Black;
            //        break;
            //}
            message += "\n";
            Console.WriteLine(message);
            Trace.Flush();
        }
    }
}
