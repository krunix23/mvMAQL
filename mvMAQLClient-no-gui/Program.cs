using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace mv.MAQL
{
class Program
{
    [DllImport("Kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();
    [DllImport("User32.dll")]
    private static extern bool ShowWindow(IntPtr hWind, int cmdShow);

    private static Logger logger_;

    static int Main(string[] args)
    {
        Console.WriteLine(string.Format("mvMAQLClient-no-gui"));
        Int32 result = -1;
        bool hideWindow = false;

        if(args.Length == 0)
        {
            Console.WriteLine("This program must be called with params.");
            return -1;
        }

        if (args.Length > 0)
        {
            foreach (string param in args)
            {
                if(param.Equals("--hide") == true)
                {
                    hideWindow = true;
                }
            }
        }

        if(hideWindow == true)
        {
            IntPtr hWind = GetConsoleWindow();
            if (hWind != IntPtr.Zero)
            {
                ShowWindow(hWind, 0);
            }
        }

        logger_ = new Logger("mvMAQLClient.log", "mvMAQLClient");
        Trace.Listeners.Add(logger_);
        MAQLWorker maql = new MAQLWorker(logger_);

        result = maql.Init(args);

        if (result == 0)
            result = maql.FetchLicense();

        if(hideWindow == false)
        {
            Console.WriteLine("Press ENTER ...");
            Console.ReadLine();
        }

        return result;
    }
}
}