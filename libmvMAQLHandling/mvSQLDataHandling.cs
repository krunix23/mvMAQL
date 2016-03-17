﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using libmvMAQLHandling;

namespace libmvMAQLHandling
{
    public class mvSQLDataHandling
    {
        private string tablename_;
        private string connstr_;
        private SqlConnection sqlcon_;

        public mvSQLDataHandling(string tablename, string connstr)
        {
            tablename_ = tablename;
            connstr_ = connstr;
            try
            {
                sqlcon_ = new SqlConnection(connstr_);
            }
            catch (SystemException ex)
            {
                Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
            }
        }

        /// <summary>
        /// Check existing data in SQL table.
        /// </summary>
        /// <param name="data">The string value to check for.</param>
        /// <returns>Returns TRUE if data already exists.</returns>
        private bool CheckExistingData(string data)
        {
            bool result = false;
            string sCmd = string.Format("SELECT * FROM [{0}] WHERE Serialnumber='{1}' OR mvBlueGEMINI='{2}' OR BlfCam_Profinet='{3}' OR BlfCam_TCP='{4}'", tablename_, data, data, data, data);

            try
            {
                SqlCommand sqlcmd = new SqlCommand(sCmd, sqlcon_);
                sqlcon_.Open();
                using (SqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Trace.WriteLine(String.Format("Data already inserted: {0} : {1}: {2}", reader["Serialnumber"], reader["mvBlueGEMINI"], reader["BlfCam_Profinet"]), "ERROR");
                        result = true;
                    }
                }
                sqlcon_.Close();
            }
            catch (SystemException ex)
            {
                Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
            }

            return result;
        }

        private List<string[]> ExecuteLineReads(string cmd)
        {
            List<string[]> lResult = new List<string[]>();

            try
            {
                SqlCommand sqlcmd = new SqlCommand(cmd, sqlcon_);
                sqlcon_.Open();
                using (SqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] sLine = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            sLine[i] = reader[i].ToString();
                        }
                        lResult.Add(sLine);
                    }
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
                //SqlCommand sqlcmd = new SqlCommand("INSERT INTO macs(Id,Serialnumber) values(@kid,@kserial)", sqlcon_);
                //sqlcmd.Parameters.AddWithValue("@kid", 23);
                //sqlcmd.Parameters.AddWithValue("@kserial", textBox1.Text);

                SqlCommand sqlcmd = new SqlCommand(cmd, sqlcon_);
                sqlcon_.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcon_.Close();
                result = true;
            }
            catch (SystemException ex)
            {
                Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
            }
            return result;
        }

        private string ExecuteRead(string colType, string cmd)
        {
            string sResult = string.Empty;

            try
            {
                SqlCommand sqlcmd = new SqlCommand(cmd, sqlcon_);
                sqlcon_.Open();
                using (SqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sResult = reader[colType].ToString();
                        break;
                    }
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
                SqlCommand sqlcmd = new SqlCommand(cmd, sqlcon_);
                sqlcon_.Open();
                using (SqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sResult = reader[colType].ToString();
                        lResult.Add(sResult);
                    }
                }
            }
            catch (SystemException ex)
            {
                Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
            }
            sqlcon_.Close();
            return lResult;
        }

        public void FindData(string data, string column)
        {
            string sCmd = string.Format("SELECT * From [{0}] WHERE {1}='{2}'", tablename_, column, data);
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

        public Int64 FindHighestMAC(string colType)
        {
            Int64 result = 0;

            string sCmd = string.Format("SELECT {0} FROM [{1}] WHERE {2}<>'NULL' ORDER BY {3} ASC", colType, tablename_, colType, colType);
            List<string> lResult = ExecuteReads(colType, sCmd);

            if (lResult.Count > 0)
            {
                //result = libmvMAQLHelper.SpreadsheetHandling.MACStringToInt64(lResult[lResult.Count - 1]);
                result = mvSQLDataHandling.MACStringToInt64(lResult[lResult.Count - 1]);
            }

            return result;
        }

        public string FindMAC(string colType, string mac)
        {
            string sCmd = string.Format("SELECT {0} FROM [{1}] WHERE {2}='{3}'", colType, tablename_, colType, mac);
            string sResult = ExecuteRead(colType, sCmd);

            if (sResult != string.Empty)
            {
                Trace.WriteLine(string.Format("Found {0} in table", sResult));
            }
            else
            {
                Trace.WriteLine(string.Format("Found no entry in table for {0}", mac), "ERROR");
            }
            return sResult;
        }

        public void FindMACs(string colType, string mac)
        {
            string sCmd = string.Format("SELECT {0} FROM [{1}] WHERE {2}='{3}'", colType, tablename_, colType, mac);
            List<string> lResult = ExecuteReads(colType, sCmd);

            if (lResult.Count > 0)
            {
                for (int i = 0; i < lResult.Count; i++)
                {
                    Trace.WriteLine(string.Format("Found {0} in table", lResult[i]));
                }
            }
            else
            {
                Trace.WriteLine(string.Format("Found no entry in table for {0}", mac), "ERROR");
            }
        }

        public string FindSerial(string serial)
        {
            string sCmd = string.Format("SELECT Serialnumber From [{0}] WHERE Serialnumber='{1}'", tablename_, serial);
            string sResult = ExecuteRead("Serialnumber", sCmd);

            if (sResult != string.Empty)
            {
                Trace.WriteLine(string.Format("Found {0} in table", sResult));
            }
            else
            {
                Trace.WriteLine(string.Format("Found no entry in table for {0}", serial), "ERROR");
            }
            return sResult;
        }

        public void FindSerials(string serial)
        {
            string sCmd = string.Format("SELECT Serialnumber From [{0}] WHERE Serialnumber='{1}'", tablename_, serial);
            List<string> lResult = ExecuteReads("Serialnumber", sCmd);

            if (lResult.Count > 0)
            {
                for (int i = 0; i < lResult.Count; i++)
                {
                    Trace.WriteLine(string.Format("Found {0} in table", lResult[i]));
                }
            }
            else
            {
                Trace.WriteLine(string.Format("Found no entry in table for {0}", serial), "ERROR");
            }
        }

        public string FindUnusedMAC(string colType)
        {
            string sCmd = string.Format("SELECT {0} FROM [{1}] WHERE Serialnumber IS NULL AND {2} IS NOT NULL", colType, tablename_, colType);

            return ExecuteRead(colType, sCmd);
        }

        public void InsertMAC(string colType, string mac)
        {
            if (CheckExistingData(mac))
                return;

            ExecuteNonQuery(InsertMACCmd(colType, mac));
        }

        private string InsertMACCmd(string colType, string mac)
        {
            return string.Format("INSERT INTO {0}({1}) values('{2}')", tablename_, colType, mac);
        }

        public void InsertSerial(string serial)
        {
            if (CheckExistingData(serial))
                return;

            ExecuteNonQuery(InsertSerialCmd(serial));
        }

        private string InsertSerialCmd(string serial)
        {
            return string.Format("INSERT INTO {0}(Serialnumber) values('{1}')", tablename_, serial);
        }

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

        public void UpdateMACWithSerial(string colType, string mac, string serial)
        {
            if (CheckExistingData(serial))
            {
                //TODO ???
                return;
            }

            string sCmd = string.Format("UPDATE [macs] SET Serialnumber='{0}' WHERE {1}='{2}'", serial, colType, mac);

            ExecuteNonQuery(sCmd);

            sCmd = string.Format("SELECT Serialnumber FROM [{0}] WHERE Serialnumber='{1}' AND {2}='{3}'", tablename_, serial, colType, mac);

            Trace.WriteLine(ExecuteRead("Serialnumber", sCmd));
        }
    }
}
