namespace BiometricAttendanceBridge
{
    partial class frmEnroll
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
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.cmdDeleteCompany = new System.Windows.Forms.Button();
            this.cmdSetCompany = new System.Windows.Forms.Button();
            this.cmdGetName = new System.Windows.Forms.Button();
            this.cmdSetName = new System.Windows.Forms.Button();
            this.cmdModifyPrivilege = new System.Windows.Forms.Button();
            this.cmdEnableUser = new System.Windows.Forms.Button();
            this.cmdSetAllEnrollData = new System.Windows.Forms.Button();
            this.cmdGetAllEnrollData = new System.Windows.Forms.Button();
            this.cmdGetEnrollData = new System.Windows.Forms.Button();
            this.cmdClearData = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdGetEnrollInfo = new System.Windows.Forms.Button();
            this.cmdDeleteEnrollData = new System.Windows.Forms.Button();
            this.cmdSetEnrollData = new System.Windows.Forms.Button();
            this.cmdDel = new System.Windows.Forms.Button();
            this.btnSetUserPeriod = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdEmptyEnrollData = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkDisable = new System.Windows.Forms.CheckBox();
            this.cmbPrivilege = new System.Windows.Forms.ComboBox();
            this.lstEnrollData = new System.Windows.Forms.ListBox();
            this.txtEnrollNumber = new System.Windows.Forms.TextBox();
            this.cmbBackupNumber = new System.Windows.Forms.ComboBox();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblEnrollData = new System.Windows.Forms.Label();
            this.lblBackupNumber = new System.Windows.Forms.Label();
            this._lblEnrollNum_0 = new System.Windows.Forms.Label();
            this.cmdModifyDuressFP = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDuressSetting = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserTz2 = new System.Windows.Forms.TextBox();
            this.txtUserTz1 = new System.Windows.Forms.TextBox();
            this.txtUserTz4 = new System.Windows.Forms.TextBox();
            this.txtUserTz3 = new System.Windows.Forms.TextBox();
            this.txtUserTz5 = new System.Windows.Forms.TextBox();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.OpenFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.chkDupCheck = new System.Windows.Forms.CheckBox();
            this.cmdRemoteEnroll = new System.Windows.Forms.Button();
            this.cmdRemoteEnrollCard = new System.Windows.Forms.Button();
            this.cmdImportXls = new System.Windows.Forms.Button();
            this.cmbExcelType = new System.Windows.Forms.ComboBox();
            this.cmdExportXls = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeviceIDforExcel = new System.Windows.Forms.TextBox();
            this.cmdSetNameFromTextFile = new System.Windows.Forms.Button();
            this.btnGetUserPeriod = new System.Windows.Forms.Button();
            this.dtPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.chkUsePeriod = new System.Windows.Forms.CheckBox();
            this.cmdGetCompany = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.AcceptsReturn = true;
            this.txtCardNumber.BackColor = System.Drawing.SystemColors.Window;
            this.txtCardNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCardNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCardNumber.Location = new System.Drawing.Point(200, 124);
            this.txtCardNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCardNumber.MaxLength = 0;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCardNumber.Size = new System.Drawing.Size(107, 30);
            this.txtCardNumber.TabIndex = 71;
            // 
            // cmdDeleteCompany
            // 
            this.cmdDeleteCompany.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDeleteCompany.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdDeleteCompany.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeleteCompany.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDeleteCompany.Location = new System.Drawing.Point(1039, 308);
            this.cmdDeleteCompany.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDeleteCompany.Name = "cmdDeleteCompany";
            this.cmdDeleteCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdDeleteCompany.Size = new System.Drawing.Size(267, 37);
            this.cmdDeleteCompany.TabIndex = 69;
            this.cmdDeleteCompany.Text = "Delete Company Name";
            this.cmdDeleteCompany.UseVisualStyleBackColor = false;
            this.cmdDeleteCompany.Click += new System.EventHandler(this.cmdDeleteCompany_Click);
            // 
            // cmdSetCompany
            // 
            this.cmdSetCompany.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetCompany.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetCompany.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetCompany.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetCompany.Location = new System.Drawing.Point(1039, 268);
            this.cmdSetCompany.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSetCompany.Name = "cmdSetCompany";
            this.cmdSetCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSetCompany.Size = new System.Drawing.Size(267, 37);
            this.cmdSetCompany.TabIndex = 68;
            this.cmdSetCompany.Text = "Set Company Name";
            this.cmdSetCompany.UseVisualStyleBackColor = false;
            this.cmdSetCompany.Click += new System.EventHandler(this.cmdSetCompany_Click);
            // 
            // cmdGetName
            // 
            this.cmdGetName.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetName.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetName.Location = new System.Drawing.Point(764, 224);
            this.cmdGetName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGetName.Name = "cmdGetName";
            this.cmdGetName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetName.Size = new System.Drawing.Size(267, 37);
            this.cmdGetName.TabIndex = 66;
            this.cmdGetName.Text = "Get Name Data";
            this.ToolTip1.SetToolTip(this.cmdGetName, "Get All Enroll Data From Device And Save To DataBase");
            this.cmdGetName.UseVisualStyleBackColor = false;
            this.cmdGetName.Click += new System.EventHandler(this.cmdGetName_Click);
            // 
            // cmdSetName
            // 
            this.cmdSetName.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetName.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetName.Location = new System.Drawing.Point(1039, 224);
            this.cmdSetName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSetName.Name = "cmdSetName";
            this.cmdSetName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSetName.Size = new System.Drawing.Size(267, 37);
            this.cmdSetName.TabIndex = 65;
            this.cmdSetName.Text = "Set Name Data";
            this.ToolTip1.SetToolTip(this.cmdSetName, "Load All Enroll Data From DataBase And Set To Device");
            this.cmdSetName.UseVisualStyleBackColor = false;
            this.cmdSetName.Click += new System.EventHandler(this.cmdSetName_Click);
            // 
            // cmdModifyPrivilege
            // 
            this.cmdModifyPrivilege.BackColor = System.Drawing.SystemColors.Control;
            this.cmdModifyPrivilege.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdModifyPrivilege.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModifyPrivilege.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdModifyPrivilege.Location = new System.Drawing.Point(764, 395);
            this.cmdModifyPrivilege.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdModifyPrivilege.Name = "cmdModifyPrivilege";
            this.cmdModifyPrivilege.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdModifyPrivilege.Size = new System.Drawing.Size(267, 37);
            this.cmdModifyPrivilege.TabIndex = 64;
            this.cmdModifyPrivilege.Text = "ModifyPrivilege";
            this.cmdModifyPrivilege.UseVisualStyleBackColor = false;
            this.cmdModifyPrivilege.Click += new System.EventHandler(this.cmdModifyPrivilege_Click);
            // 
            // cmdEnableUser
            // 
            this.cmdEnableUser.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEnableUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEnableUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnableUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEnableUser.Location = new System.Drawing.Point(1039, 351);
            this.cmdEnableUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdEnableUser.Name = "cmdEnableUser";
            this.cmdEnableUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdEnableUser.Size = new System.Drawing.Size(267, 37);
            this.cmdEnableUser.TabIndex = 63;
            this.cmdEnableUser.Text = "EnableUser";
            this.cmdEnableUser.UseVisualStyleBackColor = false;
            this.cmdEnableUser.Click += new System.EventHandler(this.cmdEnableUser_Click);
            // 
            // cmdSetAllEnrollData
            // 
            this.cmdSetAllEnrollData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetAllEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetAllEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetAllEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetAllEnrollData.Location = new System.Drawing.Point(1039, 161);
            this.cmdSetAllEnrollData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSetAllEnrollData.Name = "cmdSetAllEnrollData";
            this.cmdSetAllEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSetAllEnrollData.Size = new System.Drawing.Size(267, 37);
            this.cmdSetAllEnrollData.TabIndex = 62;
            this.cmdSetAllEnrollData.Text = "Set All Enroll Data";
            this.ToolTip1.SetToolTip(this.cmdSetAllEnrollData, "Load All Enroll Data From DataBase And Set To Device");
            this.cmdSetAllEnrollData.UseVisualStyleBackColor = false;
            this.cmdSetAllEnrollData.Click += new System.EventHandler(this.cmdSetAllEnrollData_Click);
            // 
            // cmdGetAllEnrollData
            // 
            this.cmdGetAllEnrollData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetAllEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetAllEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetAllEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetAllEnrollData.Location = new System.Drawing.Point(764, 159);
            this.cmdGetAllEnrollData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGetAllEnrollData.Name = "cmdGetAllEnrollData";
            this.cmdGetAllEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetAllEnrollData.Size = new System.Drawing.Size(267, 37);
            this.cmdGetAllEnrollData.TabIndex = 61;
            this.cmdGetAllEnrollData.Text = "Get All Enroll Data";
            this.ToolTip1.SetToolTip(this.cmdGetAllEnrollData, "Get All Enroll Data From Device And Save To DataBase");
            this.cmdGetAllEnrollData.UseVisualStyleBackColor = false;
            this.cmdGetAllEnrollData.Click += new System.EventHandler(this.cmdGetAllEnrollData_Click);
            // 
            // cmdGetEnrollData
            // 
            this.cmdGetEnrollData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetEnrollData.Location = new System.Drawing.Point(764, 74);
            this.cmdGetEnrollData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGetEnrollData.Name = "cmdGetEnrollData";
            this.cmdGetEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetEnrollData.Size = new System.Drawing.Size(267, 37);
            this.cmdGetEnrollData.TabIndex = 60;
            this.cmdGetEnrollData.Text = "Get Enroll Data";
            this.ToolTip1.SetToolTip(this.cmdGetEnrollData, "Get EnrollData From Device");
            this.cmdGetEnrollData.UseVisualStyleBackColor = false;
            this.cmdGetEnrollData.Click += new System.EventHandler(this.cmdGetEnrollData_Click);
            // 
            // cmdClearData
            // 
            this.cmdClearData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdClearData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdClearData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClearData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdClearData.Location = new System.Drawing.Point(1039, 487);
            this.cmdClearData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdClearData.Name = "cmdClearData";
            this.cmdClearData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdClearData.Size = new System.Drawing.Size(267, 37);
            this.cmdClearData.TabIndex = 59;
            this.cmdClearData.Text = "Clear All Data(E,GL,SL) ";
            this.ToolTip1.SetToolTip(this.cmdClearData, "Clear EnrollData and LogDat Into Device");
            this.cmdClearData.UseVisualStyleBackColor = false;
            this.cmdClearData.Click += new System.EventHandler(this.cmdClearData_Click);
            // 
            // cmdGetEnrollInfo
            // 
            this.cmdGetEnrollInfo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetEnrollInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetEnrollInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetEnrollInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetEnrollInfo.Location = new System.Drawing.Point(764, 351);
            this.cmdGetEnrollInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGetEnrollInfo.Name = "cmdGetEnrollInfo";
            this.cmdGetEnrollInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetEnrollInfo.Size = new System.Drawing.Size(267, 37);
            this.cmdGetEnrollInfo.TabIndex = 57;
            this.cmdGetEnrollInfo.Text = "Get Enroll Info";
            this.ToolTip1.SetToolTip(this.cmdGetEnrollInfo, "Get All Enrolled User Info From Device");
            this.cmdGetEnrollInfo.UseVisualStyleBackColor = false;
            this.cmdGetEnrollInfo.Click += new System.EventHandler(this.cmdGetEnrollInfo_Click);
            // 
            // cmdDeleteEnrollData
            // 
            this.cmdDeleteEnrollData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDeleteEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdDeleteEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeleteEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDeleteEnrollData.Location = new System.Drawing.Point(1039, 117);
            this.cmdDeleteEnrollData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDeleteEnrollData.Name = "cmdDeleteEnrollData";
            this.cmdDeleteEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdDeleteEnrollData.Size = new System.Drawing.Size(267, 37);
            this.cmdDeleteEnrollData.TabIndex = 56;
            this.cmdDeleteEnrollData.Text = "Delete Enroll Data";
            this.ToolTip1.SetToolTip(this.cmdDeleteEnrollData, "Delete Enroll Data Into Device");
            this.cmdDeleteEnrollData.UseVisualStyleBackColor = false;
            this.cmdDeleteEnrollData.Click += new System.EventHandler(this.cmdDeleteEnrollData_Click);
            // 
            // cmdSetEnrollData
            // 
            this.cmdSetEnrollData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetEnrollData.Location = new System.Drawing.Point(1039, 74);
            this.cmdSetEnrollData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSetEnrollData.Name = "cmdSetEnrollData";
            this.cmdSetEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSetEnrollData.Size = new System.Drawing.Size(267, 37);
            this.cmdSetEnrollData.TabIndex = 55;
            this.cmdSetEnrollData.Text = "Set Enroll Data";
            this.ToolTip1.SetToolTip(this.cmdSetEnrollData, "Set EnrollData To Device");
            this.cmdSetEnrollData.UseVisualStyleBackColor = false;
            this.cmdSetEnrollData.Click += new System.EventHandler(this.cmdSetEnrollData_Click);
            // 
            // cmdDel
            // 
            this.cmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdDel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDel.Location = new System.Drawing.Point(568, 838);
            this.cmdDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdDel.Size = new System.Drawing.Size(133, 37);
            this.cmdDel.TabIndex = 47;
            this.cmdDel.Text = "Delete DB";
            this.ToolTip1.SetToolTip(this.cmdDel, "Delete All Saved Data From DataBase");
            this.cmdDel.UseVisualStyleBackColor = false;
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // btnSetUserPeriod
            // 
            this.btnSetUserPeriod.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetUserPeriod.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSetUserPeriod.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetUserPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSetUserPeriod.Location = new System.Drawing.Point(1039, 695);
            this.btnSetUserPeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetUserPeriod.Name = "btnSetUserPeriod";
            this.btnSetUserPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSetUserPeriod.Size = new System.Drawing.Size(267, 37);
            this.btnSetUserPeriod.TabIndex = 113;
            this.btnSetUserPeriod.Text = "SetUserPeriod";
            this.ToolTip1.SetToolTip(this.btnSetUserPeriod, "Clear EnrollData and LogDat Into Device");
            this.btnSetUserPeriod.UseVisualStyleBackColor = false;
            this.btnSetUserPeriod.Click += new System.EventHandler(this.btnSetUserPeriod_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
            this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdExit.Location = new System.Drawing.Point(911, 838);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdExit.Size = new System.Drawing.Size(267, 37);
            this.cmdExit.TabIndex = 58;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdEmptyEnrollData
            // 
            this.cmdEmptyEnrollData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEmptyEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEmptyEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmptyEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEmptyEnrollData.Location = new System.Drawing.Point(764, 487);
            this.cmdEmptyEnrollData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdEmptyEnrollData.Name = "cmdEmptyEnrollData";
            this.cmdEmptyEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdEmptyEnrollData.Size = new System.Drawing.Size(267, 37);
            this.cmdEmptyEnrollData.TabIndex = 54;
            this.cmdEmptyEnrollData.Text = "Empty Enroll Data";
            this.cmdEmptyEnrollData.UseVisualStyleBackColor = false;
            this.cmdEmptyEnrollData.Click += new System.EventHandler(this.cmdEmptyEnrollData_Click);
            // 
            // txtName
            // 
            this.txtName.AcceptsReturn = true;
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(431, 81);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.MaxLength = 24;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(204, 30);
            this.txtName.TabIndex = 52;
            // 
            // chkDisable
            // 
            this.chkDisable.BackColor = System.Drawing.SystemColors.Control;
            this.chkDisable.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkDisable.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDisable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDisable.Location = new System.Drawing.Point(356, 128);
            this.chkDisable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDisable.Name = "chkDisable";
            this.chkDisable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDisable.Size = new System.Drawing.Size(149, 23);
            this.chkDisable.TabIndex = 49;
            this.chkDisable.Text = "Disable User";
            this.chkDisable.UseVisualStyleBackColor = false;
            // 
            // cmbPrivilege
            // 
            this.cmbPrivilege.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPrivilege.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbPrivilege.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrivilege.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPrivilege.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cmbPrivilege.Location = new System.Drawing.Point(200, 252);
            this.cmbPrivilege.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPrivilege.Name = "cmbPrivilege";
            this.cmbPrivilege.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPrivilege.Size = new System.Drawing.Size(107, 30);
            this.cmbPrivilege.TabIndex = 43;
            this.cmbPrivilege.Text = "0";
            // 
            // lstEnrollData
            // 
            this.lstEnrollData.BackColor = System.Drawing.SystemColors.Window;
            this.lstEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstEnrollData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstEnrollData.HorizontalScrollbar = true;
            this.lstEnrollData.ItemHeight = 16;
            this.lstEnrollData.Location = new System.Drawing.Point(356, 183);
            this.lstEnrollData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstEnrollData.Name = "lstEnrollData";
            this.lstEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstEnrollData.Size = new System.Drawing.Size(292, 164);
            this.lstEnrollData.TabIndex = 40;
            // 
            // txtEnrollNumber
            // 
            this.txtEnrollNumber.AcceptsReturn = true;
            this.txtEnrollNumber.BackColor = System.Drawing.SystemColors.Window;
            this.txtEnrollNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEnrollNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnrollNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEnrollNumber.Location = new System.Drawing.Point(200, 79);
            this.txtEnrollNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEnrollNumber.MaxLength = 8;
            this.txtEnrollNumber.Name = "txtEnrollNumber";
            this.txtEnrollNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEnrollNumber.Size = new System.Drawing.Size(107, 30);
            this.txtEnrollNumber.TabIndex = 38;
            this.txtEnrollNumber.Text = "1";
            // 
            // cmbBackupNumber
            // 
            this.cmbBackupNumber.BackColor = System.Drawing.SystemColors.Window;
            this.cmbBackupNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbBackupNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBackupNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBackupNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cmbBackupNumber.Location = new System.Drawing.Point(200, 212);
            this.cmbBackupNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBackupNumber.Name = "cmbBackupNumber";
            this.cmbBackupNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBackupNumber.Size = new System.Drawing.Size(107, 30);
            this.cmbBackupNumber.TabIndex = 36;
            this.cmbBackupNumber.Text = "0";
            // 
            // lblCardNum
            // 
            this.lblCardNum.BackColor = System.Drawing.SystemColors.Control;
            this.lblCardNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCardNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCardNum.Location = new System.Drawing.Point(29, 129);
            this.lblCardNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCardNum.Size = new System.Drawing.Size(163, 48);
            this.lblCardNum.TabIndex = 70;
            this.lblCardNum.Text = "Card or Password Number :";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.SystemColors.Control;
            this.lbName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbName.Location = new System.Drawing.Point(367, 87);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbName.Size = new System.Drawing.Size(67, 22);
            this.lbName.TabIndex = 53;
            this.lbName.Text = "Name :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(517, 154);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(67, 22);
            this.Label2.TabIndex = 48;
            this.Label2.Text = "Total : ";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(29, 254);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(94, 22);
            this.Label1.TabIndex = 44;
            this.Label1.Text = "Privilege :";
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMessage.Location = new System.Drawing.Point(19, 21);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMessage.Size = new System.Drawing.Size(704, 36);
            this.lblMessage.TabIndex = 42;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEnrollData
            // 
            this.lblEnrollData.AutoSize = true;
            this.lblEnrollData.BackColor = System.Drawing.SystemColors.Control;
            this.lblEnrollData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblEnrollData.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnrollData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEnrollData.Location = new System.Drawing.Point(357, 153);
            this.lblEnrollData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnrollData.Name = "lblEnrollData";
            this.lblEnrollData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblEnrollData.Size = new System.Drawing.Size(132, 22);
            this.lblEnrollData.TabIndex = 41;
            this.lblEnrollData.Text = "Enrolled Data :";
            // 
            // lblBackupNumber
            // 
            this.lblBackupNumber.AutoSize = true;
            this.lblBackupNumber.BackColor = System.Drawing.SystemColors.Control;
            this.lblBackupNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBackupNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBackupNumber.Location = new System.Drawing.Point(29, 217);
            this.lblBackupNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackupNumber.Name = "lblBackupNumber";
            this.lblBackupNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBackupNumber.Size = new System.Drawing.Size(148, 22);
            this.lblBackupNumber.TabIndex = 39;
            this.lblBackupNumber.Text = "Backup Number :";
            // 
            // _lblEnrollNum_0
            // 
            this._lblEnrollNum_0.AutoSize = true;
            this._lblEnrollNum_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblEnrollNum_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEnrollNum_0.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEnrollNum_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEnrollNum_0.Location = new System.Drawing.Point(29, 84);
            this._lblEnrollNum_0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblEnrollNum_0.Name = "_lblEnrollNum_0";
            this._lblEnrollNum_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEnrollNum_0.Size = new System.Drawing.Size(139, 22);
            this._lblEnrollNum_0.TabIndex = 37;
            this._lblEnrollNum_0.Text = "Enroll Number :";
            // 
            // cmdModifyDuressFP
            // 
            this.cmdModifyDuressFP.BackColor = System.Drawing.SystemColors.Control;
            this.cmdModifyDuressFP.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdModifyDuressFP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModifyDuressFP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdModifyDuressFP.Location = new System.Drawing.Point(1039, 394);
            this.cmdModifyDuressFP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdModifyDuressFP.Name = "cmdModifyDuressFP";
            this.cmdModifyDuressFP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdModifyDuressFP.Size = new System.Drawing.Size(267, 37);
            this.cmdModifyDuressFP.TabIndex = 72;
            this.cmdModifyDuressFP.Text = "Modify Duress FP";
            this.cmdModifyDuressFP.UseVisualStyleBackColor = false;
            this.cmdModifyDuressFP.Click += new System.EventHandler(this.cmdModifyDuressFP_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(29, 299);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(71, 22);
            this.label4.TabIndex = 76;
            this.label4.Text = "Duress:";
            // 
            // cmbDuressSetting
            // 
            this.cmbDuressSetting.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDuressSetting.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbDuressSetting.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDuressSetting.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDuressSetting.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbDuressSetting.Location = new System.Drawing.Point(200, 293);
            this.cmbDuressSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDuressSetting.Name = "cmbDuressSetting";
            this.cmbDuressSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDuressSetting.Size = new System.Drawing.Size(107, 30);
            this.cmbDuressSetting.TabIndex = 77;
            this.cmbDuressSetting.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(29, 391);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(91, 22);
            this.label5.TabIndex = 78;
            this.label5.Text = "User TZ1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(29, 430);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(91, 22);
            this.label6.TabIndex = 79;
            this.label6.Text = "User TZ2:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(29, 466);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(91, 22);
            this.label7.TabIndex = 80;
            this.label7.Text = "User TZ3:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(29, 500);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(91, 22);
            this.label8.TabIndex = 81;
            this.label8.Text = "User TZ4:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(29, 532);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(91, 22);
            this.label9.TabIndex = 82;
            this.label9.Text = "User TZ5:";
            // 
            // txtUserTz2
            // 
            this.txtUserTz2.AcceptsReturn = true;
            this.txtUserTz2.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserTz2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserTz2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserTz2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserTz2.Location = new System.Drawing.Point(200, 422);
            this.txtUserTz2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserTz2.MaxLength = 0;
            this.txtUserTz2.Name = "txtUserTz2";
            this.txtUserTz2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserTz2.Size = new System.Drawing.Size(107, 30);
            this.txtUserTz2.TabIndex = 84;
            // 
            // txtUserTz1
            // 
            this.txtUserTz1.AcceptsReturn = true;
            this.txtUserTz1.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserTz1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserTz1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserTz1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserTz1.Location = new System.Drawing.Point(200, 388);
            this.txtUserTz1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserTz1.MaxLength = 8;
            this.txtUserTz1.Name = "txtUserTz1";
            this.txtUserTz1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserTz1.Size = new System.Drawing.Size(107, 30);
            this.txtUserTz1.TabIndex = 83;
            // 
            // txtUserTz4
            // 
            this.txtUserTz4.AcceptsReturn = true;
            this.txtUserTz4.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserTz4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserTz4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserTz4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserTz4.Location = new System.Drawing.Point(200, 491);
            this.txtUserTz4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserTz4.MaxLength = 0;
            this.txtUserTz4.Name = "txtUserTz4";
            this.txtUserTz4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserTz4.Size = new System.Drawing.Size(107, 30);
            this.txtUserTz4.TabIndex = 86;
            // 
            // txtUserTz3
            // 
            this.txtUserTz3.AcceptsReturn = true;
            this.txtUserTz3.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserTz3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserTz3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserTz3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserTz3.Location = new System.Drawing.Point(200, 457);
            this.txtUserTz3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserTz3.MaxLength = 8;
            this.txtUserTz3.Name = "txtUserTz3";
            this.txtUserTz3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserTz3.Size = new System.Drawing.Size(107, 30);
            this.txtUserTz3.TabIndex = 85;
            // 
            // txtUserTz5
            // 
            this.txtUserTz5.AcceptsReturn = true;
            this.txtUserTz5.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserTz5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserTz5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserTz5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserTz5.Location = new System.Drawing.Point(200, 526);
            this.txtUserTz5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserTz5.MaxLength = 0;
            this.txtUserTz5.Name = "txtUserTz5";
            this.txtUserTz5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserTz5.Size = new System.Drawing.Size(107, 30);
            this.txtUserTz5.TabIndex = 87;
            // 
            // txtDepart
            // 
            this.txtDepart.AcceptsReturn = true;
            this.txtDepart.BackColor = System.Drawing.SystemColors.Window;
            this.txtDepart.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDepart.Location = new System.Drawing.Point(200, 578);
            this.txtDepart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDepart.MaxLength = 0;
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDepart.Size = new System.Drawing.Size(107, 30);
            this.txtDepart.TabIndex = 89;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(29, 585);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(106, 22);
            this.label10.TabIndex = 88;
            this.label10.Text = "User Depart";
            // 
            // OpenFileDlg
            // 
            this.OpenFileDlg.FileName = "openFileDialog1";
            // 
            // chkDupCheck
            // 
            this.chkDupCheck.AutoSize = true;
            this.chkDupCheck.Checked = true;
            this.chkDupCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDupCheck.Location = new System.Drawing.Point(1041, 201);
            this.chkDupCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDupCheck.Name = "chkDupCheck";
            this.chkDupCheck.Size = new System.Drawing.Size(215, 21);
            this.chkDupCheck.TabIndex = 91;
            this.chkDupCheck.Text = "Fingerprint Duplication Check";
            this.chkDupCheck.UseVisualStyleBackColor = true;
            // 
            // cmdRemoteEnroll
            // 
            this.cmdRemoteEnroll.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRemoteEnroll.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdRemoteEnroll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoteEnroll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRemoteEnroll.Location = new System.Drawing.Point(764, 441);
            this.cmdRemoteEnroll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdRemoteEnroll.Name = "cmdRemoteEnroll";
            this.cmdRemoteEnroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdRemoteEnroll.Size = new System.Drawing.Size(267, 37);
            this.cmdRemoteEnroll.TabIndex = 64;
            this.cmdRemoteEnroll.Text = "Remote Enroll";
            this.cmdRemoteEnroll.UseVisualStyleBackColor = false;
            this.cmdRemoteEnroll.Click += new System.EventHandler(this.cmdRemoteEnroll_Click);
            // 
            // cmdRemoteEnrollCard
            // 
            this.cmdRemoteEnrollCard.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRemoteEnrollCard.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdRemoteEnrollCard.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoteEnrollCard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRemoteEnrollCard.Location = new System.Drawing.Point(1039, 440);
            this.cmdRemoteEnrollCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdRemoteEnrollCard.Name = "cmdRemoteEnrollCard";
            this.cmdRemoteEnrollCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdRemoteEnrollCard.Size = new System.Drawing.Size(267, 37);
            this.cmdRemoteEnrollCard.TabIndex = 64;
            this.cmdRemoteEnrollCard.Text = "Remote Enroll Card";
            this.cmdRemoteEnrollCard.UseVisualStyleBackColor = false;
            this.cmdRemoteEnrollCard.Click += new System.EventHandler(this.cmdRemoteEnrollCard_Click);
            // 
            // cmdImportXls
            // 
            this.cmdImportXls.BackColor = System.Drawing.SystemColors.Control;
            this.cmdImportXls.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdImportXls.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportXls.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdImportXls.Location = new System.Drawing.Point(1039, 583);
            this.cmdImportXls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdImportXls.Name = "cmdImportXls";
            this.cmdImportXls.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdImportXls.Size = new System.Drawing.Size(267, 37);
            this.cmdImportXls.TabIndex = 54;
            this.cmdImportXls.Text = "Import Excel File (S300)";
            this.cmdImportXls.UseVisualStyleBackColor = false;
            this.cmdImportXls.Click += new System.EventHandler(this.cmdImportXls_Click);
            // 
            // cmbExcelType
            // 
            this.cmbExcelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExcelType.FormattingEnabled = true;
            this.cmbExcelType.Items.AddRange(new object[] {
            "Simplified Chinese",
            "Simplified Chinese, Single Shift",
            "Traditional Chinese",
            "Traditional Chinese, Single Shift",
            "English",
            "English, Single Shift",
            "Thai",
            "Thai, Single Shift"});
            this.cmbExcelType.Location = new System.Drawing.Point(764, 593);
            this.cmbExcelType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbExcelType.Name = "cmbExcelType";
            this.cmbExcelType.Size = new System.Drawing.Size(265, 24);
            this.cmbExcelType.TabIndex = 93;
            // 
            // cmdExportXls
            // 
            this.cmdExportXls.BackColor = System.Drawing.SystemColors.Control;
            this.cmdExportXls.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdExportXls.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportXls.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdExportXls.Location = new System.Drawing.Point(1039, 628);
            this.cmdExportXls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExportXls.Name = "cmdExportXls";
            this.cmdExportXls.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdExportXls.Size = new System.Drawing.Size(267, 37);
            this.cmdExportXls.TabIndex = 54;
            this.cmdExportXls.Text = "Export Excel File (S300)";
            this.cmdExportXls.UseVisualStyleBackColor = false;
            this.cmdExportXls.Click += new System.EventHandler(this.cmdExportXls_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(764, 647);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 94;
            this.label3.Text = "Device ID:";
            // 
            // txtDeviceIDforExcel
            // 
            this.txtDeviceIDforExcel.Location = new System.Drawing.Point(851, 639);
            this.txtDeviceIDforExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDeviceIDforExcel.Name = "txtDeviceIDforExcel";
            this.txtDeviceIDforExcel.Size = new System.Drawing.Size(179, 22);
            this.txtDeviceIDforExcel.TabIndex = 95;
            this.txtDeviceIDforExcel.Text = "1";
            // 
            // cmdSetNameFromTextFile
            // 
            this.cmdSetNameFromTextFile.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSetNameFromTextFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSetNameFromTextFile.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetNameFromTextFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSetNameFromTextFile.Location = new System.Drawing.Point(1039, 532);
            this.cmdSetNameFromTextFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSetNameFromTextFile.Name = "cmdSetNameFromTextFile";
            this.cmdSetNameFromTextFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSetNameFromTextFile.Size = new System.Drawing.Size(267, 37);
            this.cmdSetNameFromTextFile.TabIndex = 65;
            this.cmdSetNameFromTextFile.Text = "Set Name From TextFile";
            this.cmdSetNameFromTextFile.UseVisualStyleBackColor = false;
            this.cmdSetNameFromTextFile.Click += new System.EventHandler(this.cmdSetNameFromTextFile_Click);
            // 
            // btnGetUserPeriod
            // 
            this.btnGetUserPeriod.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetUserPeriod.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetUserPeriod.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetUserPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetUserPeriod.Location = new System.Drawing.Point(764, 695);
            this.btnGetUserPeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetUserPeriod.Name = "btnGetUserPeriod";
            this.btnGetUserPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGetUserPeriod.Size = new System.Drawing.Size(267, 37);
            this.btnGetUserPeriod.TabIndex = 112;
            this.btnGetUserPeriod.Text = "GetUserPeriod";
            this.btnGetUserPeriod.UseVisualStyleBackColor = false;
            this.btnGetUserPeriod.Click += new System.EventHandler(this.btnGetUserPeriod_Click);
            // 
            // dtPeriodTo
            // 
            this.dtPeriodTo.Enabled = false;
            this.dtPeriodTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPeriodTo.Location = new System.Drawing.Point(465, 766);
            this.dtPeriodTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPeriodTo.Name = "dtPeriodTo";
            this.dtPeriodTo.Size = new System.Drawing.Size(235, 30);
            this.dtPeriodTo.TabIndex = 111;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTo.Location = new System.Drawing.Point(387, 769);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTo.Size = new System.Drawing.Size(37, 22);
            this.lblTo.TabIndex = 110;
            this.lblTo.Text = "To:";
            // 
            // dtPeriodFrom
            // 
            this.dtPeriodFrom.Enabled = false;
            this.dtPeriodFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPeriodFrom.Location = new System.Drawing.Point(465, 730);
            this.dtPeriodFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPeriodFrom.Name = "dtPeriodFrom";
            this.dtPeriodFrom.Size = new System.Drawing.Size(235, 30);
            this.dtPeriodFrom.TabIndex = 109;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.SystemColors.Control;
            this.lblFrom.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFrom.Location = new System.Drawing.Point(387, 734);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFrom.Size = new System.Drawing.Size(58, 22);
            this.lblFrom.TabIndex = 108;
            this.lblFrom.Text = "From:";
            // 
            // chkUsePeriod
            // 
            this.chkUsePeriod.BackColor = System.Drawing.SystemColors.Control;
            this.chkUsePeriod.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkUsePeriod.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsePeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUsePeriod.Location = new System.Drawing.Point(361, 695);
            this.chkUsePeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkUsePeriod.Name = "chkUsePeriod";
            this.chkUsePeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkUsePeriod.Size = new System.Drawing.Size(191, 32);
            this.chkUsePeriod.TabIndex = 107;
            this.chkUsePeriod.Text = "Use Period";
            this.chkUsePeriod.UseVisualStyleBackColor = false;
            this.chkUsePeriod.CheckedChanged += new System.EventHandler(this.chkUsePeriod_CheckedChanged);
            // 
            // cmdGetCompany
            // 
            this.cmdGetCompany.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGetCompany.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGetCompany.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetCompany.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGetCompany.Location = new System.Drawing.Point(764, 268);
            this.cmdGetCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmdGetCompany.Name = "cmdGetCompany";
            this.cmdGetCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGetCompany.Size = new System.Drawing.Size(267, 37);
            this.cmdGetCompany.TabIndex = 69;
            this.cmdGetCompany.Text = "Get Company Name";
            this.cmdGetCompany.UseVisualStyleBackColor = false;
            this.cmdGetCompany.Click += new System.EventHandler(this.cmdGetCompany_Click);
            // 
            // frmEnroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 890);
            this.Controls.Add(this.btnSetUserPeriod);
            this.Controls.Add(this.btnGetUserPeriod);
            this.Controls.Add(this.dtPeriodTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtPeriodFrom);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.chkUsePeriod);
            this.Controls.Add(this.txtDeviceIDforExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbExcelType);
            this.Controls.Add(this.chkDupCheck);
            this.Controls.Add(this.cmdSetAllEnrollData);
            this.Controls.Add(this.txtDepart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUserTz5);
            this.Controls.Add(this.txtUserTz4);
            this.Controls.Add(this.txtUserTz3);
            this.Controls.Add(this.txtUserTz2);
            this.Controls.Add(this.txtUserTz1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDuressSetting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdModifyDuressFP);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.cmdGetCompany);
            this.Controls.Add(this.cmdDeleteCompany);
            this.Controls.Add(this.cmdSetCompany);
            this.Controls.Add(this.cmdGetName);
            this.Controls.Add(this.cmdSetNameFromTextFile);
            this.Controls.Add(this.cmdSetName);
            this.Controls.Add(this.cmdRemoteEnrollCard);
            this.Controls.Add(this.cmdRemoteEnroll);
            this.Controls.Add(this.cmdModifyPrivilege);
            this.Controls.Add(this.cmdEnableUser);
            this.Controls.Add(this.cmdGetAllEnrollData);
            this.Controls.Add(this.cmdGetEnrollData);
            this.Controls.Add(this.cmdClearData);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdGetEnrollInfo);
            this.Controls.Add(this.cmdDeleteEnrollData);
            this.Controls.Add(this.cmdSetEnrollData);
            this.Controls.Add(this.cmdExportXls);
            this.Controls.Add(this.cmdImportXls);
            this.Controls.Add(this.cmdEmptyEnrollData);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkDisable);
            this.Controls.Add(this.cmdDel);
            this.Controls.Add(this.cmbPrivilege);
            this.Controls.Add(this.lstEnrollData);
            this.Controls.Add(this.txtEnrollNumber);
            this.Controls.Add(this.cmbBackupNumber);
            this.Controls.Add(this.lblCardNum);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblEnrollData);
            this.Controls.Add(this.lblBackupNumber);
            this.Controls.Add(this._lblEnrollNum_0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEnroll";
            this.Text = "frmEnroll";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEnroll_FormClosed);
            this.Load += new System.EventHandler(this.frmEnroll_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtCardNumber;
        public System.Windows.Forms.Button cmdDeleteCompany;
        public System.Windows.Forms.Button cmdSetCompany;
        public System.Windows.Forms.Button cmdGetName;
        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.Button cmdSetName;
        public System.Windows.Forms.Button cmdModifyPrivilege;
        public System.Windows.Forms.Button cmdEnableUser;
        public System.Windows.Forms.Button cmdSetAllEnrollData;
        public System.Windows.Forms.Button cmdGetAllEnrollData;
        public System.Windows.Forms.Button cmdGetEnrollData;
        public System.Windows.Forms.Button cmdClearData;
        public System.Windows.Forms.Button cmdGetEnrollInfo;
        public System.Windows.Forms.Button cmdDeleteEnrollData;
        public System.Windows.Forms.Button cmdSetEnrollData;
        public System.Windows.Forms.Button cmdDel;
        public System.Windows.Forms.Button cmdExit;
        public System.Windows.Forms.Button cmdEmptyEnrollData;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.CheckBox chkDisable;
        public System.Windows.Forms.ComboBox cmbPrivilege;
        public System.Windows.Forms.ListBox lstEnrollData;
        public System.Windows.Forms.TextBox txtEnrollNumber;
        public System.Windows.Forms.ComboBox cmbBackupNumber;
        public System.Windows.Forms.Label lblCardNum;
        public System.Windows.Forms.Label lbName;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label lblMessage;
        public System.Windows.Forms.Label lblEnrollData;
        public System.Windows.Forms.Label lblBackupNumber;
        public System.Windows.Forms.Label _lblEnrollNum_0;
        public System.Windows.Forms.Button cmdModifyDuressFP;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbDuressSetting;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtUserTz2;
        public System.Windows.Forms.TextBox txtUserTz1;
        public System.Windows.Forms.TextBox txtUserTz4;
        public System.Windows.Forms.TextBox txtUserTz3;
        public System.Windows.Forms.TextBox txtUserTz5;
        public System.Windows.Forms.TextBox txtDepart;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog OpenFileDlg;
        private System.Windows.Forms.CheckBox chkDupCheck;
        public System.Windows.Forms.Button cmdRemoteEnroll;
        public System.Windows.Forms.Button cmdRemoteEnrollCard;
		public System.Windows.Forms.Button cmdImportXls;
		private System.Windows.Forms.ComboBox cmbExcelType;
		public System.Windows.Forms.Button cmdExportXls;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDeviceIDforExcel;
        public System.Windows.Forms.Button cmdSetNameFromTextFile;
		public System.Windows.Forms.Button btnSetUserPeriod;
		public System.Windows.Forms.Button btnGetUserPeriod;
		private System.Windows.Forms.DateTimePicker dtPeriodTo;
		public System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.DateTimePicker dtPeriodFrom;
		public System.Windows.Forms.Label lblFrom;
		public System.Windows.Forms.CheckBox chkUsePeriod;
        public System.Windows.Forms.Button cmdGetCompany;
    }
}