﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace mv.MAQL
{
public class mvOSQLDataHandling : mvSQLDataHandlingBase
{
    private string tablename_;
    private string connstr_;
    private MySqlConnection sqlcon_;

    public mvOSQLDataHandling(string tablename, string connstr)
    {
        tablename_ = tablename;
        connstr_ = connstr;
        try
        {
            sqlcon_ = new MySqlConnection(connstr_);
            LockTable();
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
    }

    public override void Dispose()
    {
        sqlcon_.Close();
        UnlockTable();
    }

    public override bool DisposeLicense(string col, string mac)
    {
        bool result = false;
        string cmd = string.Format("DELETE FROM {0} WHERE License IS NOT NULL AND {1}='{2}'", tablename_, col, mac);

        result = ExecuteNonQuery(cmd);
        return result;
    }

    public override bool DisposeSerialnumber(string serial)
    {
        bool result = false;

        if ((serial == "RESERVED") || (string.IsNullOrEmpty(serial)))
        {
            Trace.WriteLine(string.Format("Deleting Serialnumber \"{0}\" is not allowed", serial), "ERROR");
            return result;
        }

        if (string.IsNullOrEmpty(FindSerial(serial)) == false)
        {
            string cmd = string.Format("UPDATE {0} SET Serialnumber = NULL WHERE Serialnumber='{1}'", tablename_, serial);
            result = ExecuteNonQuery(cmd);
        }
        else
        {
            Trace.WriteLine(string.Format("Serialnumber {0} to be de deleted can't be found in table", serial), "ERROR");
        }

        return result;
    }

    private void LockTable()
    {
        string cmd = string.Format("LOCK TABLES {0} WRITE", tablename_);
        ExecuteNonQuery(cmd);
    }

    private void UnlockTable()
    {
        string cmd = string.Format("UNLOCK TABLES");
        ExecuteNonQuery(cmd);
    }

    /// <summary>
    /// Check existing data in SQL table.
    /// </summary>
    /// <param name="data">The string value to check for.</param>
    /// <returns>Returns TRUE if data already exists.</returns>
    private bool CheckExistingData(string data)
    {
        ConfigHandling cfg_ = new ConfigHandling();
        string[] sTypes = cfg_.GetAllTypes();
        string sCmdSub = string.Empty;
        bool result = false;

        if(data.Contains(" "))
        {
            Trace.WriteLine(string.Format("Whitespace are not allowed ({0})", data), "ERROR");
            return true;
        }

        if(sTypes.Length > 0)
        {
            for(int i = 0; i < sTypes.Length; i++)
            {
                sCmdSub += string.Format(" OR {0}='{1}'", sTypes[i], data);
            }
        }

        string sCmd = string.Format("SELECT * FROM {0} WHERE Serialnumber='{1}'{2}", tablename_, data, sCmdSub);

        try
        {
            MySqlCommand sqlcmd = new MySqlCommand(sCmd, sqlcon_);
            sqlcon_.Open();
            MySqlDataReader reader = sqlcmd.ExecuteReader();
            while(reader.Read())
            {
                string tmp = null;
                if(reader.FieldCount > 0)
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        if(reader.GetDataTypeName(i).Equals("VARCHAR"))
                            tmp += reader[i].ToString() + " - ";
                    }
                }
                Trace.WriteLine(String.Format("Found in table: {0}", tmp));
                result = true;
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }

        sqlcon_.Close();
        return result;
    }

    private List<string[]> ExecuteLineReads(string cmd)
    {
        List<string[]> lResult = new List<string[]>();

        try
        {
            MySqlCommand sqlcmd = new MySqlCommand(cmd, sqlcon_);
            sqlcon_.Open();
            MySqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                string[] sLine = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if(reader.GetDataTypeName(i).Equals("VARCHAR"))
                        sLine[i] = reader[i].ToString();
                }
                lResult.Add(sLine);
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        sqlcon_.Close();
        return lResult;
    }

    private bool ExecuteNonQuery(string cmd)
    {
        bool result = false;

        try
        {
            MySqlCommand sqlcmd = new MySqlCommand(cmd, sqlcon_);
            sqlcon_.Open();
            int ret = sqlcmd.ExecuteNonQuery();
            if (ret > 0)
                result = true;
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        sqlcon_.Close();
        return result;
    }

    private string ExecuteRead(string colType, string cmd)
    {
        string sResult = string.Empty;

        try
        {
            MySqlCommand sqlcmd = new MySqlCommand(cmd, sqlcon_);
            sqlcon_.Open();
            MySqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                sResult = reader[colType].ToString();
                break;
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        sqlcon_.Close();
        return sResult;
    }

    private List<string> ExecuteReads(string colType, string cmd)
    {
        string sResult = string.Empty;
        List<string> lResult = new List<string>();

        try
        {
            sqlcon_.Open();
            MySqlCommand sqlcmd = new MySqlCommand(cmd, sqlcon_);
            MySqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                sResult = reader[colType].ToString();
                lResult.Add(sResult);
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        sqlcon_.Close();
        return lResult;
    }

    private string MACFromLicenseFileName( string licenseFile )
    {
        string result = string.Empty;
        string sMACtmp = licenseFile.Substring(8, 12);
        Int64 iMAC = Convert.ToInt64(sMACtmp, 16);
        return MACInt64ToString(iMAC);
    }

    public override void FindData(string data, string column)
    {
        string sCmd = string.Format("SELECT * From {0} WHERE {1}='{2}'", tablename_, column, data);
        List<string[]> lResult = ExecuteLineReads(sCmd);

        if (lResult.Count > 0)
        {
            for (int i = 0; i < lResult.Count; i++)
            {
                string sLine = string.Empty;
                string[] aLine = lResult[i];
                for (int j = 0; j < aLine.Length; j++)
                {
                    if (aLine[j] != string.Empty)
                        sLine += aLine[j] + " ";
                }
                Trace.WriteLine(string.Format("Found in table: {0}", sLine));
            }
        }
        else
        {
            Trace.WriteLine(string.Format("Found no entry in table for {0}", data), "ERROR");
        }
    }

    public override Int64 FindHighestMAC(string colType)
    {
        Int64 result = 0;

        string sCmd = string.Format("SELECT {0} FROM {1} WHERE {2}<>'NULL' ORDER BY {3} ASC", colType, tablename_, colType, colType);
        List<string> lResult = ExecuteReads(colType, sCmd);

        if (lResult.Count > 0)
        {
            result = mvSQLDataHandlingBase.MACStringToInt64(lResult[lResult.Count - 1]);
        }

        return result;
    }

    public override string FindMAC(string colType, string sMAC)
    {
        string sCmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'", colType, tablename_, colType, sMAC.ToUpper());
        string sResult = ExecuteRead(colType, sCmd);

        if (sResult != string.Empty)
        {
            Trace.WriteLine(string.Format("Found in table: {0}", sResult));
        }
        else
        {
            Trace.WriteLine(string.Format("Found no entry in table for {0}", sMAC.ToUpper()), "ERROR");
        }
        return sResult;
    }

    public override void FindMACs(string colType, string sMAC)
    {
        string sCmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'", colType, tablename_, colType, sMAC.ToUpper());
        List<string> lResult = ExecuteReads(colType, sCmd);

        if (lResult.Count > 0)
        {
            for (int i = 0; i < lResult.Count; i++)
            {
                Trace.WriteLine(string.Format("Found in table: {0}", lResult[i]));
            }
        }
        else
        {
            Trace.WriteLine(string.Format("Found no entry in table for {0}", sMAC.ToUpper()), "ERROR");
        }
    }

    public override string FindMACBySerial(string coltype, string serial)
    {
        string result = string.Empty;

        string sCmd = string.Format("SELECT {0} FROM {1} WHERE Serialnumber='{2}'", coltype, tablename_, serial);
        List<string> lResult = ExecuteReads(coltype, sCmd);

        if (lResult.Count > 0)
        {
            for (int i = 0; i < lResult.Count; i++)
            {
                Trace.WriteLine(string.Format("Found MAC in table: {0}", lResult[i]));
                result = lResult[i];
            }
        }
        else
        {
            Trace.WriteLine(string.Format("Found no entry in table for {0}", serial), "ERROR");
        }

        return result;
    }

    public override string FindSerial(string serial)
    {
        string sCmd = string.Format("SELECT Serialnumber From {0} WHERE Serialnumber='{1}'", tablename_, serial);
        string sResult = ExecuteRead("Serialnumber", sCmd);

        if (sResult != string.Empty)
        {
            Trace.WriteLine(string.Format("Found in table: {0}", sResult));
        }
        else
        {
            Trace.WriteLine(string.Format("Found no entry in table for {0}", serial), "ERROR");
        }
        return sResult;
    }

    public override void FindSerials(string serial)
    {
        string sCmd = string.Format("SELECT Serialnumber From {0} WHERE Serialnumber='{1}'", tablename_, serial);
        List<string> lResult = ExecuteReads("Serialnumber", sCmd);

        if (lResult.Count > 0)
        {
            for (int i = 0; i < lResult.Count; i++)
            {
                Trace.WriteLine(string.Format("Found in table: {0}", lResult[i]));
            }
        }
        else
        {
            Trace.WriteLine(string.Format("Found no entry in table for {0}", serial), "ERROR");
        }
    }

    public override string FindUnusedMAC(string colType)
    {
        string sCmd = string.Format("SELECT {0} FROM {1} WHERE Serialnumber IS NULL AND {2} IS NOT NULL", colType, tablename_, colType);

        return ExecuteRead(colType, sCmd);
    }

    public override bool InsertLicenseFile(string colType, string sMAC, string fileName)
    {
        bool result = false;

        if (string.IsNullOrEmpty(fileName) || (File.Exists(fileName) == false))
        {
            Trace.WriteLine(string.Format("The license file could not be located."), "ERROR");
            return result;
        }

        if (!CheckExistingData(sMAC.ToUpper()))
        {
            Trace.WriteLine(string.Format("The data \"{0}\" couldn't be found in the table", sMAC.ToUpper()), "ERROR");
            return result;
        }

        byte[] fileBuf = File.ReadAllBytes(fileName);
        string license64 = Convert.ToBase64String(fileBuf);
        string sCmd = string.Format("UPDATE {0} SET License=CONVERT('{1}',BINARY) WHERE {2}='{3}'", tablename_, license64, colType, sMAC.ToUpper());

        result = ExecuteNonQuery(sCmd);
        //RetrieveLicenseFile(colType, sMAC);
        return result;
    }

    public override bool InsertMAC(string colType, string sMAC)
    {
        bool result = false;

        if (CheckExistingData(sMAC.ToUpper()))
            return result;

        result = ExecuteNonQuery(InsertMACCmd(colType, sMAC.ToUpper()));

        return result;
    }

    private string InsertMACCmd(string colType, string sMAC)
    {
        return string.Format("INSERT INTO {0}({1}) values('{2}')", tablename_, colType, sMAC);
    }

    public override void InsertSerial(string serial)
    {
        if (CheckExistingData(serial))
            return;

        ExecuteNonQuery(InsertSerialCmd(serial));
    }

    private string InsertSerialCmd(string serial)
    {
        return string.Format("INSERT INTO {0}(Serialnumber) values('{1}')", tablename_, serial);
    }

    public override string LoadLicensesFromFolder(string colType, string sFolder)
    {
        string result = string.Empty;
        Char delimiter =  '\\';

        if (string.IsNullOrEmpty(sFolder))
            return result;

        string[] sFilePaths = Directory.GetFiles(sFolder, "*.dat");

        for(int i = 0; i < sFilePaths.Length; i++)
        {
            if (string.IsNullOrEmpty(sFilePaths[i]))
                continue;

            string[] sLicenseFile = sFilePaths[i].Split(delimiter);

            string sMAC = MACFromLicenseFileName(sLicenseFile[sLicenseFile.Length - 1]);

            result = sMAC;
            InsertMAC(colType, sMAC);
            InsertLicenseFile(colType, sMAC, sFilePaths[i]);
        }
        return result;
    }

    public override byte[] RetrieveLicenseFile(string colType, string sMAC)
    {
        string sCmd = string.Format("SELECT License FROM {0} WHERE {1}='{2}'", tablename_, colType, sMAC);

        try
        {
            MySqlCommand sqlcmd = new MySqlCommand(sCmd, sqlcon_);
            sqlcon_.Open();
            MySqlDataReader reader = sqlcmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                int maxBufferSize = 1024;
                byte[] outByte = new byte[maxBufferSize];
                long startIndex = 0;
                long retval;
                retval = reader.GetBytes(0, startIndex, outByte, 0, maxBufferSize);
                string result = System.Text.Encoding.UTF8.GetString(outByte, 0, (int)retval);
                byte[] license = Convert.FromBase64String(result);
                sqlcon_.Close();
                UpdateDateTime(colType, sMAC);
                return license;
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        sqlcon_.Close();

        return null;
    }

    public override bool UpdateDateTime(string colType, string sMAC)
    {
        bool result = false;
        DateTime localDate = DateTime.Now;
        var culture = new CultureInfo("de-DE");
        string sCmd = string.Format("UPDATE {0} SET Date='{1}' WHERE {2}='{3}'", tablename_, localDate.ToString(culture), colType, sMAC);
        result = ExecuteNonQuery(sCmd);
        return result;
    }

    public override bool UpdateDateTime(string colType, string sMAC, string serial)
    {
        bool result = false;
        DateTime localDate = DateTime.Now;
        var culture = new CultureInfo("de-DE");
        string sCmd = string.Format("UPDATE {0} SET Date='{1}' WHERE Serialnumber='{2}' AND {3}='{4}'", tablename_, localDate.ToString(culture), serial, colType, sMAC);
        result = ExecuteNonQuery(sCmd);
        return result;
    }

    public override bool UpdateMACWithSerial(string colType, string sMAC, string serial)
    {
        bool result = false;
        if (CheckExistingData(serial) == false)
        {
            string sCmd = string.Format("UPDATE {0} SET Serialnumber='{1}' WHERE {2}='{3}'", tablename_, serial, colType, sMAC);
            result = ExecuteNonQuery(sCmd);

            UpdateDateTime(colType, sMAC, serial);

            sCmd = string.Format("SELECT Serialnumber FROM {0} WHERE Serialnumber='{1}' AND {2}='{3}'", tablename_, serial, colType, sMAC);

            Trace.WriteLine(ExecuteRead("Serialnumber", sCmd));

            return result;
        }
        else
        {
            //TODO ???
            return result;
        }
    }
}
}
