using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System.Diagnostics;

namespace mv.MAQL.Helper
{
public class SpreadsheetHandling
{
    ConfigHandling cfgdoc_;
    private List<string> lMACs_;

    public List<string> LoadedMACs
    {
        get {
            return lMACs_;
        }
    }

    public SpreadsheetHandling(ConfigHandling cfgdoc)
    {
        cfgdoc_ = cfgdoc;
        lMACs_ = new List<string>();
        Trace.WriteLine("Created ConfigHandler");
    }

    public void GenerateSpreadsheet(string type, string mac1st, decimal nummacs)
    {
        if (mac1st.Contains(" ") ||  mac1st == string.Empty || Decimal.ToInt32(nummacs) == 0)
        {
            return;
        }

        try
        {
            string[] sMacs = new string[Decimal.ToInt32(nummacs)];
            int iStepWidth = cfgdoc_.GetStepwidth(type);
            SLDocument slDoc = new SLDocument();

            if (iStepWidth < 1)
            {
                Trace.WriteLine("The stepwidth for MAC creation is invalid", "ERROR");
            }
            slDoc.SetColumnWidth("A", 25.0);
            slDoc.SetCellValue("A1", type);

            sMacs[0] = mac1st;

            for (int i = 1; i < Decimal.ToInt32(nummacs); i++)
            {

                string tmpMAC = sMacs[i - 1];
                Int64 iMAC = MACStringToInt64(tmpMAC);
                iMAC += iStepWidth;
                sMacs[i] = MACInt64ToString(iMAC);
            }

            for (int i = 0; i < sMacs.Length; i++)
            {
                string sCell = "A" + (i + 2).ToString();
                slDoc.SetCellValue(sCell, sMacs[i]);
                Trace.WriteLine(string.Format("New MAC: {0}", sMacs[i]));
            }

            slDoc.SaveAs(type + ".xlsx");
            Trace.WriteLine(string.Format("Saved {0} MACs to {1}.xlsx", sMacs.Length, type), "INFO");
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
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

    public List<string> OpenRead(string filename)
    {
        try
        {
            SLDocument slDoc = new SLDocument(filename);

            lMACs_.Clear();

            for (int i = 0; i < 1000; i++)
            {
                string cellIndex = "A" + (i + 1).ToString();
                string curCell = slDoc.GetCellValueAsString(cellIndex);
                if (curCell == string.Empty)
                    break;
                lMACs_.Add(curCell);
                Trace.WriteLine(string.Format("Cell value: {0} = {1}", cellIndex, curCell));
            }
            if (lMACs_.Count > 0)
                return lMACs_;
        }
        catch (SystemException ex)
        {
            Trace.WriteLine(string.Format("{0}(): {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), "ERROR");
        }
        return null;
    }
}
}
