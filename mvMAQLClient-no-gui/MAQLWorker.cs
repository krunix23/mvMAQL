using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace mv.MAQL
{
    public class MAQLWorker
    {
        private ConfigHandling cfg_ = new ConfigHandling();
        private mvSQLDataHandlingBase sqldata_;
        private Logger logger_;

        private string MAC0 = string.Empty;
        private string ColType = string.Empty;
        private string Serial = string.Empty;
        private bool NeedsNewLicense = false;
        private string LicenseStoreDir = string.Empty;
        private bool LinuxOS = false;

        public MAQLWorker( TextWriterTraceListener logger)
        {
            logger_ = logger as Logger;
            cfg_ = new ConfigHandling();
            sqldata_ = new mvOSQLDataHandling(cfg_.DatabaseName(), cfg_.ConnectionString());
            LicenseStoreDir = cfg_.LicenseStoreDir();

            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                LinuxOS = true;
        }

        ~MAQLWorker()
        {
            sqldata_.Dispose();
            sqldata_ = null;
        }

        public Int32 Init(string[] args)
        {
            Int32 result = -1;

            if (args.Length > 0)
            {
                foreach (string param in args)
                {
                    Trace.WriteLine(string.Format("Input Param: {0}", param));
                    string[] tmp = param.Split('=');
                    if (tmp.Length != 2)
                        continue;
                    
                    if(tmp[0].StartsWith("MAC0"))
                        MAC0 = tmp[1];
                    else if(tmp[0].StartsWith("Type"))
                        ColType = tmp[1];
                    else if (tmp[0].StartsWith("Serial"))
                        Serial = tmp[1];
                }
            }

            if(string.IsNullOrEmpty(MAC0) || string.IsNullOrEmpty(Serial) || string.IsNullOrEmpty(ColType))
            {
                Trace.WriteLine("ERROR input params. Need: MAC0=<string> Type=<string> Serial=<string>");
                return result;
            }

            LicenseStoreDir += "\\" + ColType;

            if( mvSQLDataHandlingBase.MACStringToInt64(MAC0) == 0)
            {
                Trace.WriteLine("E2PROM seems to be invalid. Will use new license.");
                NeedsNewLicense = true;
            }
            else
            {
                Trace.WriteLine("E2PROM seems to be valid. Will try to find appropriate license file.");
                LicenseStoreDir += "\\old";
            }

            if(LinuxOS)
                LicenseStoreDir = LicenseStoreDir.Replace(@"\", "/");

            return 0;
        }

        public Int32 FetchLicense()
        {
            Int32 result = -1;
            string db_MAC0 = string.Empty;

            try
            {
                if (NeedsNewLicense == true)
                {
                    
                    db_MAC0 = sqldata_.FindUnusedMAC(ColType);
                }
                else
                {
                    db_MAC0 = sqldata_.FindMAC(ColType, MAC0.ToUpper());
                }

                if (string.IsNullOrEmpty(db_MAC0))
                {
                    Trace.WriteLine("ERROR: Can't find requested MAC0 in database.");
                    return result;
                }

                if (sqldata_.UpdateMACWithSerial(ColType, db_MAC0.ToUpper(), Serial) == true)
                {
                    result = StoreLicenseFile(ColType, db_MAC0);
                }
                else
                {
                    if (sqldata_.FindMACBySerial(ColType, Serial) == MAC0.ToUpper())
                    {
                        Trace.WriteLine(string.Format("{0} is already assinged to {1}", Serial, MAC0));
                        result = StoreLicenseFile(ColType, db_MAC0);
                    }
                    else
                    {
                        Trace.WriteLine(string.Format("ERROR: Did not fetch license file from db. Serialnumber already assigned to another MAC"));
                    }
                }
            }
            catch ( Exception ex )
            {
                Trace.WriteLine(string.Format("ERROR: Exception thrown - {0}", ex.Message));
            }

            return result;
        }

        private Int32 StoreLicenseFile(string col, string mac)
        {
            Int32 result = -1;

            try
            {
                string[] fileList;

                if(NeedsNewLicense)
                {
                    fileList = Directory.GetFiles(LicenseStoreDir, "*.dat");
                }
                else
                {
                    fileList = Directory.GetFiles(Directory.GetParent(LicenseStoreDir).FullName, "*.dat");
                }

                foreach (string f in fileList)
                {
                    File.Delete(f);
                }

                byte[] license = sqldata_.RetrieveLicenseFile(col, mac);
                string outFile = LicenseStoreDir + "\\license_" + mac.ToLower().Replace(":", "") + ".dat";

                if(LinuxOS)
                    outFile = outFile.Replace(@"\", "/");
                
                File.WriteAllBytes(outFile, license);
                Trace.WriteLine(string.Format("Saving license as {0}", outFile));
                result = 0;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(string.Format("ERROR: Exception thrown - {0}", ex.Message));
            }
            return result;
        }
    }
}
