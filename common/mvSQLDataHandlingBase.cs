﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mv.MAQL
{
public abstract class mvSQLDataHandlingBase
{
    public abstract void Dispose();
    public abstract bool DisposeLicense(string col, string mac);
    public abstract bool DisposeSerialnumber(string serial);
    public abstract void FindData(string data, string column);
    public abstract Int64 FindHighestMAC(string colType);
    public abstract string FindMAC(string colType, string sMAC);
    public abstract void FindMACs(string colType, string sMAC);
    public abstract string FindMACBySerial(string coltype, string serial);
    public abstract string FindSerial(string serial);
    public abstract void FindSerials(string serial);
    public abstract string FindUnusedMAC(string colType);
    public abstract bool InsertLicenseFile(string colType, string sMAC, string fileName);
    public abstract bool InsertMAC(string colType, string mac);
    public abstract void InsertSerial(string serial);
    public abstract string LoadLicensesFromFolder(string colType, string sFolder);
    public abstract byte[] RetrieveLicenseFile(string colType, string sMAC);
    public abstract bool UpdateDateTime(string colType, string sMAC);
    public abstract bool UpdateDateTime(string colType, string sMAC, string serial);
    public abstract bool UpdateMACWithSerial(string colType, string sMAC, string serial);

    public static string MACInt64ToString(Int64 imac)
    {
        if (imac != 0)
        {
            string sMac = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}",
                                        ((imac >> 40) & 0xff),
                                        ((imac >> 32) & 0xff),
                                        ((imac >> 24) & 0xff),
                                        ((imac >> 16) & 0xff),
                                        ((imac >> 8) & 0xff),
                                        ((imac >> 0) & 0xff));
            return sMac;
        }
        return string.Empty;
    }

    public static Int64 MACStringToInt64(string smac)
    {
        Int64 iResult = 0;

        if (smac != string.Empty)
        {
            try
            {
                string value = smac.Replace(":", "");
                iResult = Convert.ToInt64(value, 16);
            }
            catch { }
        }
        return iResult;
    }
}
}
