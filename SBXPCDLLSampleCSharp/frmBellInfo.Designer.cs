namespace BiometricAttendanceBridge
{
    partial class frmBellInfo
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
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdWrite = new System.Windows.Forms.Button();
			this.cmdRead = new System.Windows.Forms.Button();
			this.lblMessage = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbWeekday = new System.Windows.Forms.ComboBox();
			this.lstTimeZone = new System.Windows.Forms.ListBox();
			this.dtStart = new System.Windows.Forms.DateTimePicker();
			this.cmdUpdate = new System.Windows.Forms.Button();
			this.lblEnrollData = new System.Windows.Forms.Label();
			this.chkUsed = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBellCount = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBellPeriod = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cmdExit
			// 
			this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdExit.Location = new System.Drawing.Point(558, 493);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdExit.Size = new System.Drawing.Size(99, 34);
			this.cmdExit.TabIndex = 71;
			this.cmdExit.Text = "Exit";
			this.cmdExit.UseVisualStyleBackColor = false;
			this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
			// 
			// cmdWrite
			// 
			this.cmdWrite.BackColor = System.Drawing.SystemColors.Control;
			this.cmdWrite.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdWrite.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdWrite.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdWrite.Location = new System.Drawing.Point(558, 453);
			this.cmdWrite.Name = "cmdWrite";
			this.cmdWrite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdWrite.Size = new System.Drawing.Size(99, 34);
			this.cmdWrite.TabIndex = 70;
			this.cmdWrite.Text = "Write";
			this.cmdWrite.UseVisualStyleBackColor = false;
			this.cmdWrite.Click += new System.EventHandler(this.cmdWrite_Click);
			// 
			// cmdRead
			// 
			this.cmdRead.BackColor = System.Drawing.SystemColors.Control;
			this.cmdRead.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdRead.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdRead.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdRead.Location = new System.Drawing.Point(558, 413);
			this.cmdRead.Name = "cmdRead";
			this.cmdRead.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdRead.Size = new System.Drawing.Size(99, 34);
			this.cmdRead.TabIndex = 69;
			this.cmdRead.Text = "Read";
			this.cmdRead.UseVisualStyleBackColor = false;
			this.cmdRead.Click += new System.EventHandler(this.cmdRead_Click);
			// 
			// lblMessage
			// 
			this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
			this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMessage.Location = new System.Drawing.Point(14, 20);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMessage.Size = new System.Drawing.Size(654, 28);
			this.lblMessage.TabIndex = 72;
			this.lblMessage.Text = "Message";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(372, 89);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label2.Size = new System.Drawing.Size(70, 19);
			this.label2.TabIndex = 88;
			this.label2.Text = "Weekday:";
			// 
			// cmbWeekday
			// 
			this.cmbWeekday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbWeekday.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.cmbWeekday.FormattingEnabled = true;
			this.cmbWeekday.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Everyday"});
			this.cmbWeekday.Location = new System.Drawing.Point(376, 113);
			this.cmbWeekday.Name = "cmbWeekday";
			this.cmbWeekday.Size = new System.Drawing.Size(154, 27);
			this.cmbWeekday.TabIndex = 87;
			// 
			// lstTimeZone
			// 
			this.lstTimeZone.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.lstTimeZone.FormattingEnabled = true;
			this.lstTimeZone.ItemHeight = 19;
			this.lstTimeZone.Location = new System.Drawing.Point(34, 146);
			this.lstTimeZone.Name = "lstTimeZone";
			this.lstTimeZone.Size = new System.Drawing.Size(501, 384);
			this.lstTimeZone.TabIndex = 86;
			this.lstTimeZone.SelectedIndexChanged += new System.EventHandler(this.lstTimeZone_SelectedIndexChanged);
			// 
			// dtStart
			// 
			this.dtStart.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.dtStart.CustomFormat = "hh:mm:ss";
			this.dtStart.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtStart.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtStart.Location = new System.Drawing.Point(175, 114);
			this.dtStart.Name = "dtStart";
			this.dtStart.Size = new System.Drawing.Size(119, 26);
			this.dtStart.TabIndex = 85;
			this.dtStart.Value = new System.DateTime(2011, 10, 12, 10, 44, 0, 0);
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.BackColor = System.Drawing.SystemColors.Control;
			this.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdUpdate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdUpdate.Location = new System.Drawing.Point(558, 147);
			this.cmdUpdate.Name = "cmdUpdate";
			this.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdUpdate.Size = new System.Drawing.Size(104, 46);
			this.cmdUpdate.TabIndex = 84;
			this.cmdUpdate.Text = "Update";
			this.cmdUpdate.UseVisualStyleBackColor = false;
			this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
			// 
			// lblEnrollData
			// 
			this.lblEnrollData.AutoSize = true;
			this.lblEnrollData.BackColor = System.Drawing.SystemColors.Control;
			this.lblEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblEnrollData.Location = new System.Drawing.Point(171, 89);
			this.lblEnrollData.Name = "lblEnrollData";
			this.lblEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblEnrollData.Size = new System.Drawing.Size(41, 19);
			this.lblEnrollData.TabIndex = 83;
			this.lblEnrollData.Text = "Time:";
			// 
			// chkUsed
			// 
			this.chkUsed.AutoSize = true;
			this.chkUsed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkUsed.Location = new System.Drawing.Point(34, 113);
			this.chkUsed.Name = "chkUsed";
			this.chkUsed.Size = new System.Drawing.Size(60, 23);
			this.chkUsed.TabIndex = 89;
			this.chkUsed.Text = "Used";
			this.chkUsed.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(30, 57);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(76, 19);
			this.label1.TabIndex = 88;
			this.label1.Text = "Bell Count:";
			// 
			// txtBellCount
			// 
			this.txtBellCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBellCount.Location = new System.Drawing.Point(126, 55);
			this.txtBellCount.Name = "txtBellCount";
			this.txtBellCount.Size = new System.Drawing.Size(100, 26);
			this.txtBellCount.TabIndex = 90;
			this.txtBellCount.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.SystemColors.Control;
			this.label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(269, 56);
			this.label3.Name = "label3";
			this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label3.Size = new System.Drawing.Size(79, 19);
			this.label3.TabIndex = 88;
			this.label3.Text = "Bell Period:";
			// 
			// txtBellPeriod
			// 
			this.txtBellPeriod.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBellPeriod.Location = new System.Drawing.Point(365, 54);
			this.txtBellPeriod.Name = "txtBellPeriod";
			this.txtBellPeriod.Size = new System.Drawing.Size(100, 26);
			this.txtBellPeriod.TabIndex = 90;
			this.txtBellPeriod.Text = "1";
			// 
			// frmBellInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(680, 564);
			this.Controls.Add(this.txtBellPeriod);
			this.Controls.Add(this.txtBellCount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkUsed);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbWeekday);
			this.Controls.Add(this.lstTimeZone);
			this.Controls.Add(this.dtStart);
			this.Controls.Add(this.cmdUpdate);
			this.Controls.Add(this.lblEnrollData);
			this.Controls.Add(this.cmdExit);
			this.Controls.Add(this.cmdWrite);
			this.Controls.Add(this.cmdRead);
			this.Controls.Add(this.lblMessage);
			this.Name = "frmBellInfo";
			this.Text = "frmBellInfo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBellInfo_FormClosing);
			this.Load += new System.EventHandler(this.frmBellInfo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		public System.Windows.Forms.Button cmdExit;
        public System.Windows.Forms.Button cmdWrite;
		public System.Windows.Forms.Button cmdRead;
		public System.Windows.Forms.Label lblMessage;
		public System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbWeekday;
		private System.Windows.Forms.ListBox lstTimeZone;
		private System.Windows.Forms.DateTimePicker dtStart;
		public System.Windows.Forms.Button cmdUpdate;
		public System.Windows.Forms.Label lblEnrollData;
		private System.Windows.Forms.CheckBox chkUsed;
		public System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBellCount;
		public System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtBellPeriod;
    }
}