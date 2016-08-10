using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;

namespace mv.MAQL.Helper
{
public class ConfigHandling
{
    XmlDocument cfgdoc_;

    public ConfigHandling()
    {
        try
        {
            cfgdoc_ = new XmlDocument();
            cfgdoc_.Load("config.xml");
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        //Trace.WriteLine("Created ConfigHandler");
    }

    public string ConnectionString()
    {
        string sResult = string.Empty;
        try
        {
            XmlNodeList elemList = cfgdoc_.GetElementsByTagName("database");
            if (elemList.Count > 0)
            {
                sResult = elemList[0].Attributes["connstr"].Value;
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        return sResult;
    }

    public string DatabaseName()
    {
        string sResult = string.Empty;
        try
        {
            XmlNodeList elemList = cfgdoc_.GetElementsByTagName("database");
            if (elemList.Count > 0)
            {
                sResult = elemList[0].Attributes["tablename"].Value;
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        return sResult;
    }

    public string DatabaseProvider()
    {
        string sResult = string.Empty;
        try
        {
            XmlNodeList elemList = cfgdoc_.GetElementsByTagName("database");
            if (elemList.Count > 0)
            {
                sResult = elemList[0].Attributes["provider"].Value;
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        return sResult;
    }

    public string[] GetAllTypes()
    {
        try
        {
            XmlNodeList elemList = cfgdoc_.GetElementsByTagName("camera");
            string[] sResults = new string[elemList.Count];

            for (int i = 0; i < elemList.Count; i++)
            {
                string attrType = elemList[i].Attributes["type"].Value;
                string attrMac = elemList[i].Attributes["mac"].Value;
                //Trace.WriteLine(string.Format("Definition found for: {0} - {1}", attrType, attrMac));
                sResults[i] = attrType;
            }
            return sResults;
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
            return null;
        }
    }

    public string GetDefaultMAC(string type)
    {
        try
        {
            XmlNodeList elemList = cfgdoc_.GetElementsByTagName("camera");

            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].Attributes["type"].Value == type)
                {
                    return elemList[i].Attributes["mac"].Value;
                }
            }
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        return string.Empty;
    }

    public int GetStepwidth(string type)
    {
        XmlNodeList elemList = cfgdoc_.GetElementsByTagName("camera");

        for (int i = 0; i < elemList.Count; i++)
        {
            if (elemList[i].Attributes["type"].Value == type)
            {
                return int.Parse(elemList[i].Attributes["step"].Value);
            }
        }
        return -1;
    }
}
}
