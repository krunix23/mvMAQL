using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mv.MAQL
{
class Program
{
    private static ConfigHandling cfg_;
    private static mvSQLDataHandlingBase sqldata_;

    static int Main(string[] args)
    {
        Console.WriteLine(string.Format("mvMAQLClient-no-gui"));

        cfg_ = new ConfigHandling ();
        sqldata_ = new mvOSQLDataHandling (cfg_.DatabaseName (), cfg_.ConnectionString ());

        sqldata_.FindData ("MS000241", "Serialnumber");

        Console.WriteLine ("Press ENTER ...");
        Console.ReadLine();

        return 0;
    }
}
}
