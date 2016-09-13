using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace mv.MAQL
{
public partial class Form1 : Form
{
    private Rectangle tabArea;
    private RectangleF tabTextArea;

    private Logger logger_;
    //private mvMSQLDataHandling sqldata_;
    private mvSQLDataHandlingBase sqldata_;
    private ConfigHandling cfg_;
    private SpreadsheetHandling exc_;

    public Form1()
    {
        InitializeComponent();
        tabArea = tabControl1.GetTabRect(0);
        tabTextArea = (RectangleF)tabControl1.GetTabRect(0);
        logger_ = new Logger(richTextBox, "mvMAQLClient.log", "mvMAQLClient");
        Trace.Listeners.Add(logger_);
        cfg_ = new ConfigHandling();
        exc_ = new SpreadsheetHandling(cfg_);

        if (cfg_.DatabaseProvider() != string.Empty)
        {
            if (cfg_.DatabaseProvider() == "oracle")
                sqldata_ = new mvOSQLDataHandling(cfg_.DatabaseName(), cfg_.ConnectionString());
            else
                throw new SystemException("No valid database provider found in config.xml");
        }
        else
        {
            throw new SystemException("Couldn't determine database provider from config.xml");
        }

        string[] sTypes = cfg_.GetAllTypes();
        for (int i = 0; i < sTypes.Length; i++)
        {
            comboBoxType.Items.Add(sTypes[i]);
        }
        comboBoxType.SelectedIndex = 0;
        textBoxInsertLicense.Text = @"C:\Users\matrix\halcon\mvBlueGEMINI\old\license_000c8d000cf1.dat";
        textBoxMACLicenseFile.Text = "00:0C:8D:00:0C:F1";
    }

    private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sType = comboBoxType.SelectedItem.ToString();
        string sMac = cfg_.GetDefaultMAC(sType);
        Trace.WriteLine(string.Format("Selected camera type: {0}", sType), "INFO");
        if (sMac != string.Empty)
        {
            textBoxFirstMAC.Text = sMac;
        }
        Int64 lastMAC = sqldata_.FindHighestMAC(sType);
        if(lastMAC > 0)
        {
            textBoxFirstMAC.Text = mvSQLDataHandlingBase.MACInt64ToString(lastMAC);
        }
    }

    private void buttonInsertMAC_Click(object sender, EventArgs e)
    {
        sqldata_.InsertMAC(comboBoxType.Text, textBoxInsertMAC.Text);
    }

    private void buttonSearchSerial_Click(object sender, EventArgs e)
    {
        sqldata_.FindData(textBoxSearchSerial.Text, "Serialnumber");
    }

    private void buttonSearchMAC_Click(object sender, EventArgs e)
    {
        sqldata_.FindData(textBoxSearchMAC.Text.ToUpper(), comboBoxType.Text);
    }

    private void buttonAssignSerialMACFree_Click(object sender, EventArgs e)
    {
        string sMac = sqldata_.FindUnusedMAC(comboBoxType.Text);
        if ((sMac != string.Empty) && (textBoxAssignSerialFreeMAC.Text != string.Empty))
        {
            sqldata_.UpdateMACWithSerial(comboBoxType.Text, sMac, textBoxAssignSerialFreeMAC.Text);
        }
        else
        {
            Trace.WriteLine(string.Format("Assign Serial={0} to free MAC failed!", textBoxAssignSerialFreeMAC.Text), "ERROR");
        }
    }

    private void buttonAssignSerialMAC_Click(object sender, EventArgs e)
    {
        string sMAC = sqldata_.FindMAC(comboBoxType.Text, textBoxAssignMAC.Text);
        if ((sMAC != string.Empty) && (textBoxAssignMAC.Text != string.Empty))
        {
            sqldata_.UpdateMACWithSerial(comboBoxType.Text, sMAC, textBoxAssignSerial.Text);
        }
        else
        {
            Trace.WriteLine(string.Format("Assign Serial={0} to MAC={1} failed!", textBoxAssignSerial.Text, sMAC), "ERROR");
        }

    }

    private void buttonCreate_Click(object sender, EventArgs e)
    {
        exc_.GenerateSpreadsheet(comboBoxType.Text, textBoxFirstMAC.Text, numericUpDownNumMACs.Value);
    }

    private void buttonOpenFile_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
    }

    private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
        textBoxExcelInputFile.Text = openFileDialog1.SafeFileName;
        exc_.OpenRead(openFileDialog1.FileName);
    }

    private void buttonLoad_Click(object sender, EventArgs e)
    {
        List<string> lMACs = exc_.LoadedMACs;
        if((lMACs != null) && (lMACs.Count > 0))
        {
            for(int i = 0; i < lMACs.Count; i++)
            {
                if(i == 0)
                {
                    if (lMACs[i] == comboBoxType.Text)
                        continue;
                    else
                    {
                        Trace.WriteLine(string.Format("Spreadsheet seems to be invalid for this camera type ({0})", lMACs[i]), "ERROR");
                        return;
                    }
                }
                sqldata_.InsertMAC(comboBoxType.Text, lMACs[i]);
                Trace.WriteLine(string.Format("Inserted {0} for {1}", lMACs[i], comboBoxType.Text));
            }
        }
    }

    private void buttonInsertLicense_Click(object sender, EventArgs e)
    {
        sqldata_.InsertLicenseFile(comboBoxType.Text, textBoxMACLicenseFile.Text, textBoxInsertLicense.Text);
    }

    private string checkLicenseDir(string folderName)
    {
        string result = string.Empty;
        Char delimiter =  '\\';

        if (string.IsNullOrEmpty(folderName))
            return result;

        string[] sDirs = folderName.Split(delimiter);

        string[] types = cfg_.GetAllTypes();
        for(int i = 0; i < types.Length; i++)
        {
            if(types[i] == sDirs[sDirs.Length-1])
            {
                result = types[i];
                break;
            }
        }
        return result;
    }

    private void buttonOpenDir_Click(object sender, EventArgs e)
    {
        DialogResult result = folderBrowserDialog1.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrEmpty(checkLicenseDir(folderBrowserDialog1.SelectedPath)))
        {
            Trace.WriteLine(string.Format("{0} as license dir selected", folderBrowserDialog1.SelectedPath), "INFO");
        }
    }

    private void buttonLoadDir_Click(object sender, EventArgs e)
    {
        string sType = checkLicenseDir(folderBrowserDialog1.SelectedPath);
        if (!string.IsNullOrEmpty(sType))
        {
            sqldata_.LoadLicensesFromFolder(sType, folderBrowserDialog1.SelectedPath);
        }
    }

    private void tabControl1_DrawItem_1(object sender, DrawItemEventArgs e)
    {
        //{
        //    Font font;
        //    Brush back_brush;
        //    Brush fore_brush;
        //    Rectangle bounds = e.Bounds;
        //    font = new Font(e.Font, e.Font.Style);
        //    back_brush = new SolidBrush(Color.Gainsboro);
        //    fore_brush = new SolidBrush(Color.Red);
        //    e.Graphics.FillRectangle(back_brush, e.Bounds);
        //    //also draw the text
        //    var fntTab = e.Font;
        //    var bshFore = new SolidBrush(Color.Black);
        //    string tabName = this.tabControl1.TabPages[e.Index].Text;
        //    var sftTab = new StringFormat();
        //    var recTab = new Rectangle(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height - 4);
        //    e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        //}

        //{
        //    Graphics g = e.Graphics;
        //    Pen p = new Pen(Color.Blue);
        //    Font font = new Font("Arial", 10.0f);
        //    SolidBrush brush = new SolidBrush(Color.Red);
        //    tabControl1.get
        //    g.DrawRectangle(p, tabArea);
        //    g.DrawString("tabPage1", font, brush, tabTextArea);
        //}

        //{
        //    TabControl tc = (TabControl)sender;
        //    TabPage currentTab = tc.TabPages[tc.SelectedIndex];
        //    Graphics g = e.Graphics;
        //    Font font = new Font("Arial", 10.0f);
        //    SolidBrush brushRed = new SolidBrush(Color.Red);
        //    Color[] backColors = new Color[3]{Color.Blue, Color.Green, Color.Black};
        //    Rectangle tabArea = e.Bounds;
        //    Rectangle tabTextArea = e.Bounds;
        //    Brush backBrush = new
        //    SolidBrush(backColors[tc.SelectedIndex]);
        //    g.FillRectangle(backBrush, tabArea);
        //    currentTab.BackColor = backColors[tc.SelectedIndex];
        //    g.DrawString(currentTab.Text, font, brushRed,
        //    tabTextArea);
        //}
    }

    private void buttonDeleteSerial_Click(object sender, EventArgs e)
    {
        sqldata_.DisposeSerialnumber(textBoxDeleteSerial.Text);
    }
}
}
