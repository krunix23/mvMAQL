namespace mvMAQL
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
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumMACs)).BeginInit();
            this.tabPage1.SuspendLayout();
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
            this.richTextBox.Location = new System.Drawing.Point(12, 428);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(370, 137);
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
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(362, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MACs";
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
            this.groupBox7.Text = "Load";
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
            this.groupBox6.Text = "Generate";
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
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "1st MAC";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(252, 38);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
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
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(362, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database";
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
            this.groupBox4.Size = new System.Drawing.Size(350, 100);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Assign Serial To MAC";
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
            this.buttonAssignSerialMAC.Size = new System.Drawing.Size(75, 23);
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
            this.buttonInsertMAC.Size = new System.Drawing.Size(75, 23);
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
            this.buttonSearchMAC.Size = new System.Drawing.Size(75, 23);
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
            this.buttonSearchSerial.Size = new System.Drawing.Size(75, 23);
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
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SerialNumber";
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
            this.groupBox2.Text = "Assign Serial To Free MAC";
            // 
            // buttonAssignFreeMAC
            // 
            this.buttonAssignFreeMAC.Location = new System.Drawing.Point(258, 16);
            this.buttonAssignFreeMAC.Name = "buttonAssignFreeMAC";
            this.buttonAssignFreeMAC.Size = new System.Drawing.Size(75, 23);
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
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "SerialNumber";
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
            this.tabControl1.Location = new System.Drawing.Point(12, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 361);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(395, 577);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.richTextBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumMACs)).EndInit();
            this.tabPage1.ResumeLayout(false);
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
    }
}

