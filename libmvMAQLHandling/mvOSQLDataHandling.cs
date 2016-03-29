using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using MySql.Data.MySqlClient;

namespace libmvMAQLHandling
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
            string sCmd = string.Format("SELECT * FROM {0} WHERE Serialnumber='{1}' OR mvBlueGEMINI='{2}' OR BlfCam_Profinet='{3}' OR BlfCam_TCP='{4}'", tablename_, data, data, data, data);

            try
            {
                MySqlCommand sqlcmd = new MySqlCommand(sCmd, sqlcon_);
                sqlcon_.Open();
                MySqlDataReader reader = sqlcmd.ExecuteReader();
                while(reader.Read())
                {
                    Trace.WriteLine(String.Format("Found data entry: {0} : {1} : {2} : {3}", reader["Serialnumber"], reader["mvBlueGEMINI"], reader["BlfCam_Profinet"], reader["BlfCam_TCP"]));
                    result = true;
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
                MySqlCommand sqlcmd = new MySqlCommand(cmd, sqlcon_);
                sqlcon_.Open();
                MySqlDataReader reader = sqlcmd.ExecuteReader();
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
                result = mvMSQLDataHandling.MACStringToInt64(lResult[lResult.Count - 1]);
            }

            return result;
        }

        public override string FindMAC(string colType, string mac)
        {
            string sCmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'", colType, tablename_, colType, mac);
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

        public override void FindMACs(string colType, string mac)
        {
            string sCmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'", colType, tablename_, colType, mac);
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

        public override string FindSerial(string serial)
        {
            string sCmd = string.Format("SELECT Serialnumber From {0} WHERE Serialnumber='{1}'", tablename_, serial);
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

        public override void FindSerials(string serial)
        {
            string sCmd = string.Format("SELECT Serialnumber From {0} WHERE Serialnumber='{1}'", tablename_, serial);
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

        public override string FindUnusedMAC(string colType)
        {
            string sCmd = string.Format("SELECT {0} FROM {1} WHERE Serialnumber IS NULL AND {2} IS NOT NULL", colType, tablename_, colType);

            return ExecuteRead(colType, sCmd);
        }

        public override void InsertLicenseFile(string colType, string sMAC, string fileName)
        {
            if (!CheckExistingData(sMAC))
            {
                Trace.WriteLine(string.Format("The data \"{0}\" couldn't be found in the table", sMAC), "ERROR");
                return;
            }
            byte[] fileBuf = File.ReadAllBytes(fileName);
            string license64 = Convert.ToBase64String(fileBuf);
            string sCmd = string.Format("UPDATE {0} SET License=CONVERT('{1}',BINARY) WHERE {2}='{3}'", tablename_, license64, colType, sMAC);

            ExecuteNonQuery(sCmd);
            RetrieveLicenseFile(colType, sMAC);
        }

        public override void InsertMAC(string colType, string mac)
        {
            if (CheckExistingData(mac))
                return;

            ExecuteNonQuery(InsertMACCmd(colType, mac));
        }

        private string InsertMACCmd(string colType, string mac)
        {
            return string.Format("INSERT INTO {0}({1}) values('{2}')", tablename_, colType, mac);
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
                    string outFile = Directory.GetCurrentDirectory() + "\\license_out.dat";
                    File.WriteAllBytes(outFile, license);
                    Trace.WriteLine(string.Format("Saving license as {0}", outFile));
                }
            }
            catch (SystemException ex)
            {
                Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
            }
            sqlcon_.Close();

            return null;
        }

        public override void UpdateMACWithSerial(string colType, string mac, string serial)
        {
            if (CheckExistingData(serial))
            {
                //TODO ???
                return;
            }

            string sCmd = string.Format("UPDATE {0} SET Serialnumber='{1}' WHERE {2}='{3}'", tablename_, serial, colType, mac);

            ExecuteNonQuery(sCmd);

            sCmd = string.Format("SELECT Serialnumber FROM {0} WHERE Serialnumber='{1}' AND {2}='{3}'", tablename_, serial, colType, mac);

            Trace.WriteLine(ExecuteRead("Serialnumber", sCmd));
        }
    }
}
