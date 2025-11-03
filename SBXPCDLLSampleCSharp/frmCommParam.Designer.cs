namespace SBXPCDLLSampleCSharp
{
    partial class frmCommParam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.chkUseDHCP = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEventOutType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.txtSubnetMask = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDnsObtainAuto = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDnsServer0 = new System.Windows.Forms.TextBox();
            this.txtDnsServer1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtServerDomainName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBgServerPort = new System.Windows.Forms.TextBox();
            this.btnSetDnsSettings = new System.Windows.Forms.Button();
            this.btnGetDnsSettings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.AcceptsReturn = true;
            this.txtIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIP.Location = new System.Drawing.Point(93, 93);
            this.txtIP.MaxLength = 0;
            this.txtIP.Name = "txtIP";
            this.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIP.Size = new System.Drawing.Size(113, 26);
            this.txtIP.TabIndex = 33;
            this.txtIP.Text = "192.168.1.224";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(122, 337);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(81, 33);
            this.btnSet.TabIndex = 32;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(15, 337);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(81, 33);
            this.btnGet.TabIndex = 32;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "MachineID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Server IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Server Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "UseDHCP";
            // 
            // txtMachineID
            // 
            this.txtMachineID.AcceptsReturn = true;
            this.txtMachineID.BackColor = System.Drawing.SystemColors.Window;
            this.txtMachineID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMachineID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMachineID.Location = new System.Drawing.Point(93, 23);
            this.txtMachineID.MaxLength = 0;
            this.txtMachineID.Name = "txtMachineID";
            this.txtMachineID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMachineID.Size = new System.Drawing.Size(113, 26);
            this.txtMachineID.TabIndex = 33;
            this.txtMachineID.Text = "1";
            // 
            // txtPort
            // 
            this.txtPort.AcceptsReturn = true;
            this.txtPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPort.Location = new System.Drawing.Point(93, 124);
            this.txtPort.MaxLength = 0;
            this.txtPort.Name = "txtPort";
            this.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPort.Size = new System.Drawing.Size(113, 26);
            this.txtPort.TabIndex = 33;
            this.txtPort.Text = "5005";
            // 
            // txtServerIP
            // 
            this.txtServerIP.AcceptsReturn = true;
            this.txtServerIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtServerIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServerIP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerIP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServerIP.Location = new System.Drawing.Point(93, 263);
            this.txtServerIP.MaxLength = 0;
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerIP.Size = new System.Drawing.Size(113, 26);
            this.txtServerIP.TabIndex = 33;
            this.txtServerIP.Text = "192.168.1.200";
            // 
            // txtServerPort
            // 
            this.txtServerPort.AcceptsReturn = true;
            this.txtServerPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtServerPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServerPort.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServerPort.Location = new System.Drawing.Point(93, 293);
            this.txtServerPort.MaxLength = 0;
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerPort.Size = new System.Drawing.Size(113, 26);
            this.txtServerPort.TabIndex = 33;
            this.txtServerPort.Text = "4000";
            // 
            // chkUseDHCP
            // 
            this.chkUseDHCP.AutoSize = true;
            this.chkUseDHCP.Location = new System.Drawing.Point(139, 70);
            this.chkUseDHCP.Name = "chkUseDHCP";
            this.chkUseDHCP.Size = new System.Drawing.Size(15, 14);
            this.chkUseDHCP.TabIndex = 35;
            this.chkUseDHCP.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEventOutType);
            this.groupBox1.Controls.Add(this.chkUseDHCP);
            this.groupBox1.Controls.Add(this.btnGet);
            this.groupBox1.Controls.Add(this.btnSet);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtServerPort);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtMachineID);
            this.groupBox1.Controls.Add(this.txtGateway);
            this.groupBox1.Controls.Add(this.txtSubnetMask);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 388);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication Parameters";
            // 
            // cmbEventOutType
            // 
            this.cmbEventOutType.FormattingEnabled = true;
            this.cmbEventOutType.Location = new System.Drawing.Point(93, 231);
            this.cmbEventOutType.Name = "cmbEventOutType";
            this.cmbEventOutType.Size = new System.Drawing.Size(113, 21);
            this.cmbEventOutType.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Use EventOut";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Gateway";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Subnet Mask";
            // 
            // txtGateway
            // 
            this.txtGateway.AcceptsReturn = true;
            this.txtGateway.BackColor = System.Drawing.SystemColors.Window;
            this.txtGateway.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGateway.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGateway.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGateway.Location = new System.Drawing.Point(93, 186);
            this.txtGateway.MaxLength = 0;
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGateway.Size = new System.Drawing.Size(113, 26);
            this.txtGateway.TabIndex = 33;
            this.txtGateway.Text = "192.168.1.1";
            // 
            // txtSubnetMask
            // 
            this.txtSubnetMask.AcceptsReturn = true;
            this.txtSubnetMask.BackColor = System.Drawing.SystemColors.Window;
            this.txtSubnetMask.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSubnetMask.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubnetMask.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubnetMask.Location = new System.Drawing.Point(93, 155);
            this.txtSubnetMask.MaxLength = 0;
            this.txtSubnetMask.Name = "txtSubnetMask";
            this.txtSubnetMask.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSubnetMask.Size = new System.Drawing.Size(113, 26);
            this.txtSubnetMask.TabIndex = 33;
            this.txtSubnetMask.Text = "255.255.255.0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnGetDnsSettings);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnSetDnsSettings);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtServerDomainName);
            this.groupBox2.Controls.Add(this.txtDnsServer1);
            this.groupBox2.Controls.Add(this.chkDnsObtainAuto);
            this.groupBox2.Controls.Add(this.txtDnsServer0);
            this.groupBox2.Controls.Add(this.textBgServerPort);
            this.groupBox2.Location = new System.Drawing.Point(256, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 280);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DNS Settings";
            // 
            // chkDnsObtainAuto
            // 
            this.chkDnsObtainAuto.AutoSize = true;
            this.chkDnsObtainAuto.Location = new System.Drawing.Point(21, 31);
            this.chkDnsObtainAuto.Name = "chkDnsObtainAuto";
            this.chkDnsObtainAuto.Size = new System.Drawing.Size(219, 17);
            this.chkDnsObtainAuto.TabIndex = 0;
            this.chkDnsObtainAuto.Text = "Obtain DNS server address automatically";
            this.chkDnsObtainAuto.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Preferred DNS server:";
            // 
            // txtDnsServer0
            // 
            this.txtDnsServer0.AcceptsReturn = true;
            this.txtDnsServer0.BackColor = System.Drawing.SystemColors.Window;
            this.txtDnsServer0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDnsServer0.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDnsServer0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDnsServer0.Location = new System.Drawing.Point(138, 60);
            this.txtDnsServer0.MaxLength = 0;
            this.txtDnsServer0.Name = "txtDnsServer0";
            this.txtDnsServer0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDnsServer0.Size = new System.Drawing.Size(152, 26);
            this.txtDnsServer0.TabIndex = 33;
            this.txtDnsServer0.Text = "0.0.0.0";
            // 
            // txtDnsServer1
            // 
            this.txtDnsServer1.AcceptsReturn = true;
            this.txtDnsServer1.BackColor = System.Drawing.SystemColors.Window;
            this.txtDnsServer1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDnsServer1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDnsServer1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDnsServer1.Location = new System.Drawing.Point(138, 99);
            this.txtDnsServer1.MaxLength = 0;
            this.txtDnsServer1.Name = "txtDnsServer1";
            this.txtDnsServer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDnsServer1.Size = new System.Drawing.Size(152, 26);
            this.txtDnsServer1.TabIndex = 33;
            this.txtDnsServer1.Text = "0.0.0.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Alternate DNS server:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Server domain name:";
            // 
            // txtServerDomainName
            // 
            this.txtServerDomainName.AcceptsReturn = true;
            this.txtServerDomainName.BackColor = System.Drawing.SystemColors.Window;
            this.txtServerDomainName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServerDomainName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerDomainName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServerDomainName.Location = new System.Drawing.Point(138, 141);
            this.txtServerDomainName.MaxLength = 0;
            this.txtServerDomainName.Name = "txtServerDomainName";
            this.txtServerDomainName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerDomainName.Size = new System.Drawing.Size(152, 26);
            this.txtServerDomainName.TabIndex = 33;
            this.txtServerDomainName.Text = "logserver.test.domain";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Server port:";
            // 
            // textBgServerPort
            // 
            this.textBgServerPort.AcceptsReturn = true;
            this.textBgServerPort.BackColor = System.Drawing.SystemColors.Window;
            this.textBgServerPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBgServerPort.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBgServerPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBgServerPort.Location = new System.Drawing.Point(138, 179);
            this.textBgServerPort.MaxLength = 0;
            this.textBgServerPort.Name = "textBgServerPort";
            this.textBgServerPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBgServerPort.Size = new System.Drawing.Size(152, 26);
            this.textBgServerPort.TabIndex = 33;
            this.textBgServerPort.Text = "5005";
            // 
            // btnSetDnsSettings
            // 
            this.btnSetDnsSettings.Location = new System.Drawing.Point(172, 231);
            this.btnSetDnsSettings.Name = "btnSetDnsSettings";
            this.btnSetDnsSettings.Size = new System.Drawing.Size(81, 33);
            this.btnSetDnsSettings.TabIndex = 32;
            this.btnSetDnsSettings.Text = "Set";
            this.btnSetDnsSettings.UseVisualStyleBackColor = true;
            this.btnSetDnsSettings.Click += new System.EventHandler(this.btnSetDnsSettings_Click);
            // 
            // btnGetDnsSettings
            // 
            this.btnGetDnsSettings.Location = new System.Drawing.Point(65, 231);
            this.btnGetDnsSettings.Name = "btnGetDnsSettings";
            this.btnGetDnsSettings.Size = new System.Drawing.Size(81, 33);
            this.btnGetDnsSettings.TabIndex = 32;
            this.btnGetDnsSettings.Text = "Get";
            this.btnGetDnsSettings.UseVisualStyleBackColor = true;
            this.btnGetDnsSettings.Click += new System.EventHandler(this.btnGetDnsSettings_Click);
            // 
            // frmCommParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 407);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCommParam";
            this.Text = "frmCommParam";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCommParam_FormClosed);
            this.Load += new System.EventHandler(this.frmCommParam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtMachineID;
        public System.Windows.Forms.TextBox txtPort;
        public System.Windows.Forms.TextBox txtServerIP;
        public System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.CheckBox chkUseDHCP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtGateway;
        public System.Windows.Forms.TextBox txtSubnetMask;
        private System.Windows.Forms.ComboBox cmbEventOutType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDnsObtainAuto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGetDnsSettings;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSetDnsSettings;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtServerDomainName;
        public System.Windows.Forms.TextBox txtDnsServer1;
        public System.Windows.Forms.TextBox txtDnsServer0;
        public System.Windows.Forms.TextBox textBgServerPort;
    }
}