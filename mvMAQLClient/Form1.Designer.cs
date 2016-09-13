namespace mv.MAQL
{
partial class Form1
{
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.buttonOpenDir = new System.Windows.Forms.Button();
            this.buttonLoadDir = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxMACLicenseFile = new System.Windows.Forms.TextBox();
            this.textBoxInsertLicense = new System.Windows.Forms.TextBox();
            this.buttonInsertLicense = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.textBoxExcelInputFile = new System.Windows.Forms.TextBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.numericUpDownNumMACs = new System.Windows.Forms.NumericUpDown();
            this.textBoxFirstMAC = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteSerial = new System.Windows.Forms.Button();
            this.textBoxDeleteSerial = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxAssignMAC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAssignSerialMAC = new System.Windows.Forms.Button();
            this.textBoxAssignSerial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInsertMAC = new System.Windows.Forms.TextBox();
            this.buttonInsertMAC = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSearchMAC = new System.Windows.Forms.Button();
            this.textBoxSearchMAC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSearchSerial = new System.Windows.Forms.Button();
            this.textBoxSearchSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAssignFreeMAC = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAssignSerialFreeMAC = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumMACs)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(12, 504);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(370, 193);
            this.richTextBox.TabIndex = 9;
            this.richTextBox.Text = "";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(111, 13);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(136, 21);
            this.comboBoxType.TabIndex = 0;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxType);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(12, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(370, 42);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Camera";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(362, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "License";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.buttonOpenDir);
            this.groupBox9.Controls.Add(this.buttonLoadDir);
            this.groupBox9.Location = new System.Drawing.Point(7, 206);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(349, 57);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Load license files from a directory";
            // 
            // buttonOpenDir
            // 
            this.buttonOpenDir.Location = new System.Drawing.Point(7, 19);
            this.buttonOpenDir.Name = "buttonOpenDir";
            this.buttonOpenDir.Size = new System.Drawing.Size(155, 23);
            this.buttonOpenDir.TabIndex = 1;
            this.buttonOpenDir.Text = "Choose directory";
            this.buttonOpenDir.UseVisualStyleBackColor = true;
            this.buttonOpenDir.Click += new System.EventHandler(this.buttonOpenDir_Click);
            // 
            // buttonLoadDir
            // 
            this.buttonLoadDir.Location = new System.Drawing.Point(188, 19);
            this.buttonLoadDir.Name = "buttonLoadDir";
            this.buttonLoadDir.Size = new System.Drawing.Size(155, 23);
            this.buttonLoadDir.TabIndex = 0;
            this.buttonLoadDir.Text = "Load";
            this.buttonLoadDir.UseVisualStyleBackColor = true;
            this.buttonLoadDir.Click += new System.EventHandler(this.buttonLoadDir_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.textBoxMACLicenseFile);
            this.groupBox8.Controls.Add(this.textBoxInsertLicense);
            this.groupBox8.Controls.Add(this.buttonInsertLicense);
            this.groupBox8.Location = new System.Drawing.Point(7, 270);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(349, 100);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Load license file assign to MAC";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "License file";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "MAC";
            // 
            // textBoxMACLicenseFile
            // 
            this.textBoxMACLicenseFile.Location = new System.Drawing.Point(100, 20);
            this.textBoxMACLicenseFile.Name = "textBoxMACLicenseFile";
            this.textBoxMACLicenseFile.Size = new System.Drawing.Size(136, 20);
            this.textBoxMACLicenseFile.TabIndex = 2;
            // 
            // textBoxInsertLicense
            // 
            this.textBoxInsertLicense.Location = new System.Drawing.Point(100, 64);
            this.textBoxInsertLicense.Name = "textBoxInsertLicense";
            this.textBoxInsertLicense.Size = new System.Drawing.Size(136, 20);
            this.textBoxInsertLicense.TabIndex = 1;
            // 
            // buttonInsertLicense
            // 
            this.buttonInsertLicense.Location = new System.Drawing.Point(252, 41);
            this.buttonInsertLicense.Name = "buttonInsertLicense";
            this.buttonInsertLicense.Size = new System.Drawing.Size(91, 23);
            this.buttonInsertLicense.TabIndex = 0;
            this.buttonInsertLicense.Text = "Insert";
            this.buttonInsertLicense.UseVisualStyleBackColor = true;
            this.buttonInsertLicense.Click += new System.EventHandler(this.buttonInsertLicense_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonLoad);
            this.groupBox7.Controls.Add(this.textBoxExcelInputFile);
            this.groupBox7.Controls.Add(this.buttonOpenFile);
            this.groupBox7.Location = new System.Drawing.Point(7, 113);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(349, 86);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Load MACs from a Excel file";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(7, 50);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // textBoxExcelInputFile
            // 
            this.textBoxExcelInputFile.Location = new System.Drawing.Point(100, 20);
            this.textBoxExcelInputFile.Name = "textBoxExcelInputFile";
            this.textBoxExcelInputFile.ReadOnly = true;
            this.textBoxExcelInputFile.Size = new System.Drawing.Size(136, 20);
            this.textBoxExcelInputFile.TabIndex = 1;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(7, 20);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Open";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.buttonCreate);
            this.groupBox6.Controls.Add(this.numericUpDownNumMACs);
            this.groupBox6.Controls.Add(this.textBoxFirstMAC);
            this.groupBox6.Location = new System.Drawing.Point(7, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(349, 99);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Generate MACs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Number of MACs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Last MAC in DB";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(252, 38);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(91, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // numericUpDownNumMACs
            // 
            this.numericUpDownNumMACs.Location = new System.Drawing.Point(100, 63);
            this.numericUpDownNumMACs.Name = "numericUpDownNumMACs";
            this.numericUpDownNumMACs.Size = new System.Drawing.Size(136, 20);
            this.numericUpDownNumMACs.TabIndex = 1;
            // 
            // textBoxFirstMAC
            // 
            this.textBoxFirstMAC.Location = new System.Drawing.Point(100, 19);
            this.textBoxFirstMAC.Name = "textBoxFirstMAC";
            this.textBoxFirstMAC.Size = new System.Drawing.Size(136, 20);
            this.textBoxFirstMAC.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(362, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.buttonDeleteSerial);
            this.groupBox10.Controls.Add(this.textBoxDeleteSerial);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Location = new System.Drawing.Point(6, 333);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(350, 68);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Delete";
            // 
            // buttonDeleteSerial
            // 
            this.buttonDeleteSerial.Location = new System.Drawing.Point(258, 20);
            this.buttonDeleteSerial.Name = "buttonDeleteSerial";
            this.buttonDeleteSerial.Size = new System.Drawing.Size(86, 23);
            this.buttonDeleteSerial.TabIndex = 2;
            this.buttonDeleteSerial.Text = "Delete";
            this.buttonDeleteSerial.UseVisualStyleBackColor = true;
            this.buttonDeleteSerial.Click += new System.EventHandler(this.buttonDeleteSerial_Click);
            // 
            // textBoxDeleteSerial
            // 
            this.textBoxDeleteSerial.Location = new System.Drawing.Point(101, 20);
            this.textBoxDeleteSerial.Name = "textBoxDeleteSerial";
            this.textBoxDeleteSerial.Size = new System.Drawing.Size(136, 20);
            this.textBoxDeleteSerial.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Serialnumber";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxAssignMAC);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.buttonAssignSerialMAC);
            this.groupBox4.Controls.Add(this.textBoxAssignSerial);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(6, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(350, 96);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Assign serialnumber to MAC";
            // 
            // textBoxAssignMAC
            // 
            this.textBoxAssignMAC.Location = new System.Drawing.Point(101, 61);
            this.textBoxAssignMAC.Name = "textBoxAssignMAC";
            this.textBoxAssignMAC.Size = new System.Drawing.Size(136, 20);
            this.textBoxAssignMAC.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "MAC";
            // 
            // buttonAssignSerialMAC
            // 
            this.buttonAssignSerialMAC.Location = new System.Drawing.Point(258, 39);
            this.buttonAssignSerialMAC.Name = "buttonAssignSerialMAC";
            this.buttonAssignSerialMAC.Size = new System.Drawing.Size(86, 23);
            this.buttonAssignSerialMAC.TabIndex = 2;
            this.buttonAssignSerialMAC.Text = "Assign";
            this.buttonAssignSerialMAC.UseVisualStyleBackColor = true;
            this.buttonAssignSerialMAC.Click += new System.EventHandler(this.buttonAssignSerialMAC_Click);
            // 
            // textBoxAssignSerial
            // 
            this.textBoxAssignSerial.Location = new System.Drawing.Point(101, 20);
            this.textBoxAssignSerial.Name = "textBoxAssignSerial";
            this.textBoxAssignSerial.Size = new System.Drawing.Size(136, 20);
            this.textBoxAssignSerial.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "SerialNumber";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxInsertMAC);
            this.groupBox1.Controls.Add(this.buttonInsertMAC);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 57);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insert";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "MAC";
            // 
            // textBoxInsertMAC
            // 
            this.textBoxInsertMAC.Location = new System.Drawing.Point(101, 19);
            this.textBoxInsertMAC.Name = "textBoxInsertMAC";
            this.textBoxInsertMAC.Size = new System.Drawing.Size(136, 20);
            this.textBoxInsertMAC.TabIndex = 3;
            // 
            // buttonInsertMAC
            // 
            this.buttonInsertMAC.Location = new System.Drawing.Point(258, 19);
            this.buttonInsertMAC.Name = "buttonInsertMAC";
            this.buttonInsertMAC.Size = new System.Drawing.Size(86, 23);
            this.buttonInsertMAC.TabIndex = 7;
            this.buttonInsertMAC.Text = "Insert";
            this.buttonInsertMAC.UseVisualStyleBackColor = true;
            this.buttonInsertMAC.Click += new System.EventHandler(this.buttonInsertMAC_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSearchMAC);
            this.groupBox3.Controls.Add(this.textBoxSearchMAC);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.buttonSearchSerial);
            this.groupBox3.Controls.Add(this.textBoxSearchSerial);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 94);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // buttonSearchMAC
            // 
            this.buttonSearchMAC.Location = new System.Drawing.Point(258, 57);
            this.buttonSearchMAC.Name = "buttonSearchMAC";
            this.buttonSearchMAC.Size = new System.Drawing.Size(86, 23);
            this.buttonSearchMAC.TabIndex = 5;
            this.buttonSearchMAC.Text = "Search";
            this.buttonSearchMAC.UseVisualStyleBackColor = true;
            this.buttonSearchMAC.Click += new System.EventHandler(this.buttonSearchMAC_Click);
            // 
            // textBoxSearchMAC
            // 
            this.textBoxSearchMAC.Location = new System.Drawing.Point(101, 57);
            this.textBoxSearchMAC.Name = "textBoxSearchMAC";
            this.textBoxSearchMAC.Size = new System.Drawing.Size(136, 20);
            this.textBoxSearchMAC.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "MAC";
            // 
            // buttonSearchSerial
            // 
            this.buttonSearchSerial.Location = new System.Drawing.Point(258, 20);
            this.buttonSearchSerial.Name = "buttonSearchSerial";
            this.buttonSearchSerial.Size = new System.Drawing.Size(86, 23);
            this.buttonSearchSerial.TabIndex = 2;
            this.buttonSearchSerial.Text = "Search";
            this.buttonSearchSerial.UseVisualStyleBackColor = true;
            this.buttonSearchSerial.Click += new System.EventHandler(this.buttonSearchSerial_Click);
            // 
            // textBoxSearchSerial
            // 
            this.textBoxSearchSerial.Location = new System.Drawing.Point(101, 20);
            this.textBoxSearchSerial.Name = "textBoxSearchSerial";
            this.textBoxSearchSerial.Size = new System.Drawing.Size(136, 20);
            this.textBoxSearchSerial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serialnumber";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAssignFreeMAC);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxAssignSerialFreeMAC);
            this.groupBox2.Location = new System.Drawing.Point(6, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 54);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Assign serialnumber to free MAC";
            // 
            // buttonAssignFreeMAC
            // 
            this.buttonAssignFreeMAC.Location = new System.Drawing.Point(258, 16);
            this.buttonAssignFreeMAC.Name = "buttonAssignFreeMAC";
            this.buttonAssignFreeMAC.Size = new System.Drawing.Size(86, 23);
            this.buttonAssignFreeMAC.TabIndex = 5;
            this.buttonAssignFreeMAC.Text = "Assign";
            this.buttonAssignFreeMAC.UseVisualStyleBackColor = true;
            this.buttonAssignFreeMAC.Click += new System.EventHandler(this.buttonAssignSerialMACFree_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Serialnumber";
            // 
            // textBoxAssignSerialFreeMAC
            // 
            this.textBoxAssignSerialFreeMAC.Location = new System.Drawing.Point(101, 19);
            this.textBoxAssignSerialFreeMAC.Name = "textBoxAssignSerialFreeMAC";
            this.textBoxAssignSerialFreeMAC.Size = new System.Drawing.Size(136, 20);
            this.textBoxAssignSerialFreeMAC.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 433);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(395, 711);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.richTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mvMAQL";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumMACs)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.RichTextBox richTextBox;
    private System.Windows.Forms.ComboBox comboBoxType;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.GroupBox groupBox7;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button buttonCreate;
    private System.Windows.Forms.NumericUpDown numericUpDownNumMACs;
    private System.Windows.Forms.TextBox textBoxFirstMAC;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.TextBox textBoxAssignMAC;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button buttonAssignSerialMAC;
    private System.Windows.Forms.TextBox textBoxAssignSerial;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBoxInsertMAC;
    private System.Windows.Forms.Button buttonInsertMAC;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button buttonSearchMAC;
    private System.Windows.Forms.TextBox textBoxSearchMAC;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button buttonSearchSerial;
    private System.Windows.Forms.TextBox textBoxSearchSerial;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button buttonAssignFreeMAC;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBoxAssignSerialFreeMAC;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.Button buttonOpenFile;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button buttonLoad;
    private System.Windows.Forms.TextBox textBoxExcelInputFile;
    private System.Windows.Forms.GroupBox groupBox8;
    private System.Windows.Forms.TextBox textBoxInsertLicense;
    private System.Windows.Forms.Button buttonInsertLicense;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox textBoxMACLicenseFile;
    private System.Windows.Forms.GroupBox groupBox9;
    private System.Windows.Forms.Button buttonLoadDir;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.Button buttonOpenDir;
    private System.Windows.Forms.GroupBox groupBox10;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Button buttonDeleteSerial;
    private System.Windows.Forms.TextBox textBoxDeleteSerial;
}
}

