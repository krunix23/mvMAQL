using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libmvMAQLHandling
{
    public abstract class mvSQLDataHandlingBase
    {
        public abstract void FindData(string data, string column);
        public abstract Int64 FindHighestMAC(string colType);
        public abstract string FindMAC(string colType, string mac);
        public abstract void FindMACs(string colType, string mac);
        public abstract string FindSerial(string serial);
        public abstract void FindSerials(string serial);
        public abstract string FindUnusedMAC(string colType);
        public abstract void InsertLicenseFile(string colType, string sMAC, string fileName);
        public abstract byte[] RetrieveLicenseFile(string colType, string sMAC);
        public abstract void InsertMAC(string colType, string mac);
        public abstract void InsertSerial(string serial);
        //public abstract static string MACInt64ToString(Int64 imac);
        //public abstract static Int64 MACStringToInt64(string smac);
        public abstract void UpdateMACWithSerial(string colType, string mac, string serial);
    }
}
