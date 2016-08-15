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
            Int32 result = -1;

            if(args.Length == 0)
            {
                Console.WriteLine("This program must be called with params.");
                return -1;
            }

            logger_ = new Logger("mvMAQLClient.log", "mvMAQLClient");
            Trace.Listeners.Add(logger_);
            MAQLWorker mql = new MAQLWorker(logger_);
            
            result = mql.Init(args);

            if (result == 0)
                result = mql.FetchLicense();
            
            Console.WriteLine("Press ENTER ...");
            Console.ReadLine();

            return result;
        }
    }
}