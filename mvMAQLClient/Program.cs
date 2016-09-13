using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mv.MAQL
{
static class Program
{
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        if(args.Length > 0)
        {
            Console.WriteLine("main(): numargs={0}", args.Length);
        }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        try
        {
            Form form_ = new Form1();
            Application.Run(form_);
        }
        catch(SystemException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
}
