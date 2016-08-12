using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace mv.MAQL
{
    class Program
    {
        private static Logger logger_;

        static int Main(string[] args)
        {
            Console.WriteLine(string.Format("mvMAQLClient-no-gui"));

            logger_ = new Logger("mvMAQLClient.log", "mvMAQLClient");
            Trace.Listeners.Add(logger_);
            MAQLWorker mql = new MAQLWorker(logger_);
            mql.DummyFunction();

            Console.WriteLine("Press ENTER ...");
            Console.ReadLine();

            return 0;
        }
    }
}