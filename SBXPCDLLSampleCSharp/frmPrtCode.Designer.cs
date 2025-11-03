namespace BiometricAttendanceBridge
{
    partial class frmPrtCode
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
            this.components = new System.ComponentModel.Container();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.cmdGetProductCode = new System.Windows.Forms.Button();
            this.cmdGetBackupNumber = new System.Windows.Forms.Button();
            this.txtBackupNo = new System.Windows.Forms.TextBox();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.cmdGetSerialNumber = new System.Windows.Forms.Button();
            this.lblBackuplNo = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExit = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeviceUniqueID = new System.Windows.Forms.TextBox();
            this.btnGetDeviceUniqueID = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoftwareKey = new System.Windows.Forms.TextBox();
            this.btnGetSoftwareKey = new System.Windows.Forms.Button();
            this.btnSetSoftwareKey = new System.Windows.Forms.Button();
            this.txtDeviceDetailInfo = new System.Windows.Forms.TextBox();
            this.btnGetDevDetailInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.AcceptsReturn = true;
            this.txtSerialNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtSerialNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSerialNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSerialNo.Location = new System.Drawing.Point(165, 62);
            this.txtSerialNo.MaxLength = 32;
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSerialNo.Size = new System.Drawing.Size(319, 26);
            this.txtSerialNo.TabIndex = 24;
            // 
            // txtProductCode
            // 
            this.txtProductCode.AcceptsReturn = true;
            this.txtProductCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtProductCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProductCode.Location = new System.Drawing.Point(165, 126);
            this.txtProductCode.MaxLength = 32;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProductCode.Size = new System.Drawing.Size(319, 26);
            this.txtProductCode.TabIndex = 28;
            // 
            // cmdGetProductCode
            // 
            this.cmdGetProductCode.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetProductCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetProductCode.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetProductCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetProductCode.Location = new System.Drawing.Point(263, 183);
            this.cmdGetProductCode.Name = "cmdGetProductCode";
            this.cmdGetProductCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetProductCode.Size = new System.Drawing.Size(121, 45);
            this.cmdGetProductCode.TabIndex = 27;
            this.cmdGetProductCode.Text = "Get ProductCode";
            this.cmdGetProductCode.UseVisualStyleBackColor = true;
            this.cmdGetProductCode.Click += new System.EventHandler(this.cmdGetProductCode_Click);
            // 
            // cmdGetBackupNumber
            // 
            this.cmdGetBackupNumber.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetBackupNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetBackupNumber.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetBackupNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetBackupNumber.Location = new System.Drawing.Point(136, 182);
            this.cmdGetBackupNumber.Name = "cmdGetBackupNumber";
            this.cmdGetBackupNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetBackupNumber.Size = new System.Drawing.Size(121, 45);
            this.cmdGetBackupNumber.TabIndex = 26;
            this.cmdGetBackupNumber.Text = "Get BackupNumber";
            this.cmdGetBackupNumber.UseVisualStyleBackColor = true;
            this.cmdGetBackupNumber.Click += new System.EventHandler(this.cmdGetBackupNumber_Click);
            // 
            // txtBackupNo
            // 
            this.txtBackupNo.AcceptsReturn = true;
            this.txtBackupNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtBackupNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBackupNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBackupNo.Location = new System.Drawing.Point(165, 94);
            this.txtBackupNo.MaxLength = 32;
            this.txtBackupNo.Name = "txtBackupNo";
            this.txtBackupNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackupNo.Size = new System.Drawing.Size(319, 26);
            this.txtBackupNo.TabIndex = 25;
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.AutoSize = true;
            this.lblSerialNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblSerialNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSerialNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSerialNo.Location = new System.Drawing.Point(28, 66);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSerialNo.Size = new System.Drawing.Size(115, 19);
            this.lblSerialNo.TabIndex = 30;
            this.lblSerialNo.Text = "Serial Number :";
            this.lblSerialNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdGetSerialNumber
            // 
            this.cmdGetSerialNumber.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetSerialNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetSerialNumber.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetSerialNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetSerialNumber.Location = new System.Drawing.Point(12, 182);
            this.cmdGetSerialNumber.Name = "cmdGetSerialNumber";
            this.cmdGetSerialNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetSerialNumber.Size = new System.Drawing.Size(121, 45);
            this.cmdGetSerialNumber.TabIndex = 22;
            this.cmdGetSerialNumber.Text = "Get SerialNumber";
            this.cmdGetSerialNumber.UseVisualStyleBackColor = true;
            this.cmdGetSerialNumber.Click += new System.EventHandler(this.cmdGetSerialNumber_Click);
            // 
            // lblBackuplNo
            // 
            this.lblBackuplNo.AutoSize = true;
            this.lblBackuplNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblBackuplNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBackuplNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackuplNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBackuplNo.Location = new System.Drawing.Point(28, 98);
            this.lblBackuplNo.Name = "lblBackuplNo";
            this.lblBackuplNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBackuplNo.Size = new System.Drawing.Size(127, 19);
            this.lblBackuplNo.TabIndex = 32;
            this.lblBackuplNo.Text = "Backup Number :";
            this.lblBackuplNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
            this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdExit.Location = new System.Drawing.Point(390, 182);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdExit.Size = new System.Drawing.Size(94, 45);
            this.cmdExit.TabIndex = 23;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(28, 130);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(108, 19);
            this.Label1.TabIndex = 31;
            this.Label1.Text = "Product Code :";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMessage.Location = new System.Drawing.Point(12, 22);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMessage.Size = new System.Drawing.Size(495, 28);
            this.lblMessage.TabIndex = 29;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(17, 252);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Device Unique ID :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDeviceUniqueID
            // 
            this.txtDeviceUniqueID.AcceptsReturn = true;
            this.txtDeviceUniqueID.BackColor = System.Drawing.SystemColors.Window;
            this.txtDeviceUniqueID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDeviceUniqueID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceUniqueID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeviceUniqueID.Location = new System.Drawing.Point(165, 249);
            this.txtDeviceUniqueID.MaxLength = 32;
            this.txtDeviceUniqueID.Name = "txtDeviceUniqueID";
            this.txtDeviceUniqueID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDeviceUniqueID.Size = new System.Drawing.Size(319, 26);
            this.txtDeviceUniqueID.TabIndex = 28;
            // 
            // btnGetDeviceUniqueID
            // 
            this.btnGetDeviceUniqueID.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetDeviceUniqueID.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetDeviceUniqueID.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetDeviceUniqueID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetDeviceUniqueID.Location = new System.Drawing.Point(165, 296);
            this.btnGetDeviceUniqueID.Name = "btnGetDeviceUniqueID";
            this.btnGetDeviceUniqueID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGetDeviceUniqueID.Size = new System.Drawing.Size(319, 45);
            this.btnGetDeviceUniqueID.TabIndex = 22;
            this.btnGetDeviceUniqueID.Text = "Get DeviceUniqueID";
            this.btnGetDeviceUniqueID.UseVisualStyleBackColor = true;
            this.btnGetDeviceUniqueID.Click += new System.EventHandler(this.btnGetDeviceUniqueID_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(17, 364);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "Software Key :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSoftwareKey
            // 
            this.txtSoftwareKey.AcceptsReturn = true;
            this.txtSoftwareKey.BackColor = System.Drawing.SystemColors.Window;
            this.txtSoftwareKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoftwareKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoftwareKey.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSoftwareKey.Location = new System.Drawing.Point(165, 361);
            this.txtSoftwareKey.MaxLength = 32;
            this.txtSoftwareKey.Multiline = true;
            this.txtSoftwareKey.Name = "txtSoftwareKey";
            this.txtSoftwareKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSoftwareKey.Size = new System.Drawing.Size(319, 31);
            this.txtSoftwareKey.TabIndex = 28;
            // 
            // btnGetSoftwareKey
            // 
            this.btnGetSoftwareKey.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetSoftwareKey.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetSoftwareKey.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSoftwareKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetSoftwareKey.Location = new System.Drawing.Point(21, 426);
            this.btnGetSoftwareKey.Name = "btnGetSoftwareKey";
            this.btnGetSoftwareKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGetSoftwareKey.Size = new System.Drawing.Size(218, 45);
            this.btnGetSoftwareKey.TabIndex = 22;
            this.btnGetSoftwareKey.Text = "Get Software Key";
            this.btnGetSoftwareKey.UseVisualStyleBackColor = true;
            this.btnGetSoftwareKey.Click += new System.EventHandler(this.btnGetSoftwareKey_Click);
            // 
            // btnSetSoftwareKey
            // 
            this.btnSetSoftwareKey.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetSoftwareKey.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSetSoftwareKey.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetSoftwareKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSetSoftwareKey.Location = new System.Drawing.Point(266, 426);
            this.btnSetSoftwareKey.Name = "btnSetSoftwareKey";
            this.btnSetSoftwareKey.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSetSoftwareKey.Size = new System.Drawing.Size(218, 45);
            this.btnSetSoftwareKey.TabIndex = 22;
            this.btnSetSoftwareKey.Text = "Set Software Key";
            this.btnSetSoftwareKey.UseVisualStyleBackColor = true;
            this.btnSetSoftwareKey.Click += new System.EventHandler(this.btnSetSoftwareKey_Click);
            // 
            // txtDeviceDetailInfo
            // 
            this.txtDeviceDetailInfo.Location = new System.Drawing.Point(531, 22);
            this.txtDeviceDetailInfo.Multiline = true;
            this.txtDeviceDetailInfo.Name = "txtDeviceDetailInfo";
            this.txtDeviceDetailInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDeviceDetailInfo.Size = new System.Drawing.Size(319, 370);
            this.txtDeviceDetailInfo.TabIndex = 33;
            // 
            // btnGetDevDetailInfo
            // 
            this.btnGetDevDetailInfo.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetDevDetailInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetDevDetailInfo.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetDevDetailInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetDevDetailInfo.Location = new System.Drawing.Point(531, 426);
            this.btnGetDevDetailInfo.Name = "btnGetDevDetailInfo";
            this.btnGetDevDetailInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGetDevDetailInfo.Size = new System.Drawing.Size(319, 45);
            this.btnGetDevDetailInfo.TabIndex = 22;
            this.btnGetDevDetailInfo.Text = "Get Device Detail Info";
            this.btnGetDevDetailInfo.UseVisualStyleBackColor = true;
            this.btnGetDevDetailInfo.Click += new System.EventHandler(this.btnGetDevDetailInfo_Click);
            // 
            // frmPrtCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 494);
            this.Controls.Add(this.txtDeviceDetailInfo);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.txtSoftwareKey);
            this.Controls.Add(this.txtDeviceUniqueID);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.cmdGetProductCode);
            this.Controls.Add(this.cmdGetBackupNumber);
            this.Controls.Add(this.txtBackupNo);
            this.Controls.Add(this.lblSerialNo);
            this.Controls.Add(this.btnSetSoftwareKey);
            this.Controls.Add(this.btnGetSoftwareKey);
            this.Controls.Add(this.btnGetDevDetailInfo);
            this.Controls.Add(this.btnGetDeviceUniqueID);
            this.Controls.Add(this.cmdGetSerialNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBackuplNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblMessage);
            this.Name = "frmPrtCode";
            this.Text = "frmPrtCode";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrtCode_FormClosed);
            this.Load += new System.EventHandler(this.frmPrtCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.TextBox txtSerialNo;
        public System.Windows.Forms.TextBox txtProductCode;
        public System.Windows.Forms.Button cmdGetProductCode;
        public System.Windows.Forms.Button cmdGetBackupNumber;
        public System.Windows.Forms.TextBox txtBackupNo;
        public System.Windows.Forms.Label lblSerialNo;
        public System.Windows.Forms.Button cmdGetSerialNumber;
        public System.Windows.Forms.Label lblBackuplNo;
        public System.Windows.Forms.ToolTip toolTip2;
        public System.Windows.Forms.Button cmdExit;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label lblMessage;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtDeviceUniqueID;
		public System.Windows.Forms.Button btnGetDeviceUniqueID;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox txtSoftwareKey;
		public System.Windows.Forms.Button btnGetSoftwareKey;
		public System.Windows.Forms.Button btnSetSoftwareKey;
        private System.Windows.Forms.TextBox txtDeviceDetailInfo;
        public System.Windows.Forms.Button btnGetDevDetailInfo;
    }
}