using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace mv.MAQL
{
partial class Program
{
    private static Logger logger_;
    private static ConfigHandling cfg_;
    private static mvSQLDataHandlingBase sqldata_;

    static int Main(string[] args)
    {
        Console.WriteLine(string.Format("mvMAQLClient-no-gui"));
        logger_ = new Logger("mvMAQLClient.log", "mvMAQLClient");
        Trace.Listeners.Add(logger_);

        cfg_ = new ConfigHandling ();
        sqldata_ = new mvOSQLDataHandling (cfg_.DatabaseName (), cfg_.ConnectionString ());

        sqldata_.FindData ("MS000241", "Serialnumber");
        DummyFunction();

        Console.WriteLine ("Press ENTER ...");
        Console.ReadLine();

        return 0;
    }
}
}
