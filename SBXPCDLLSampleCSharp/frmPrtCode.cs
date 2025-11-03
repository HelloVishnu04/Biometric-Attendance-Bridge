using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BiometricAttendanceBridge
{
    public partial class frmPrtCode : Form
    {
        public frmPrtCode()
        {
            InitializeComponent();
        }

        private void cmdGetSerialNumber_Click(object sender, EventArgs e)
        {
            string vSerialNumber = "";
            Boolean vRet;
            int vErrorCode = 0;

            txtSerialNo.Text = "";
            lblMessage.Text = "Waiting...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vRet = sbxpc.SBXPCDLL.GetSerialNumber(Program.gMachineNumber, out vSerialNumber);
            if (vRet)
            {
                txtSerialNo.Text = vSerialNumber;
                lblMessage.Text = "Success";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdGetBackupNumber_Click(object sender, EventArgs e)
        {
            int vBackupNumber;
            int vErrorCode = 0;
            Boolean vRet;

            lblMessage.Text = "Waiting...";
            txtBackupNo.Text = "";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vBackupNumber = sbxpc.SBXPCDLL.GetBackupNumber(Program.gMachineNumber);
            if (vBackupNumber != 0)
            {
                txtBackupNo.Text = Convert.ToString(vBackupNumber);
                lblMessage.Text = "Success";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdGetProductCode_Click(object sender, EventArgs e)
        {
            string vProductCode = "";
            Boolean vRet;
            int vErrorCode = 0;

            txtProductCode.Text = "";
            lblMessage.Text = "Waiting...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vRet = sbxpc.SBXPCDLL.GetProductCode(Program.gMachineNumber, out vProductCode);
            if (vRet)
            {
                txtProductCode.Text = vProductCode;
                lblMessage.Text = "Success";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Close();
            Application.OpenForms["frmMain"].Visible = true;
        }

        private void frmPrtCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["frmMain"].Visible = true;
        }

        private void frmPrtCode_Load(object sender, EventArgs e)
        {
        }

		private void btnGetDeviceUniqueID_Click(object sender, EventArgs e)
		{
			string vDeviceUniqueID = "";
			Boolean vRet;
			int vErrorCode = 0;

			txtDeviceUniqueID.Text = "";
			lblMessage.Text = "Waiting...";
			Application.DoEvents();

			vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
			if (!vRet)
			{
				lblMessage.Text = util.gstrNoDevice;
				return;
			}

			vRet = sbxpc.SBXPCDLL.GetDeviceUniqueID(Program.gMachineNumber, out vDeviceUniqueID);
			if (vRet)
			{
				txtDeviceUniqueID.Text = vDeviceUniqueID;
				lblMessage.Text = "Success";
			}
			else
			{
				sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
				lblMessage.Text = util.ErrorPrint(vErrorCode);
			}

			sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
		}

		private void btnGetSoftwareKey_Click(object sender, EventArgs e)
		{
			string vSoftwareKey = "";
			Boolean vRet;
			int vErrorCode = 0;

			txtSoftwareKey.Text = "";
			lblMessage.Text = "Waiting...";
			Application.DoEvents();

			vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
			if (!vRet)
			{
				lblMessage.Text = util.gstrNoDevice;
				return;
			}

			string strXML = null;
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "GetDeviceInfoExt");
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
			sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "MachineID", Program.gMachineNumber);
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "ParamName", "softwareKey");

			vRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

			if (vRet)
			{
				if(sbxpc.SBXPCDLL.XML_ParseString(ref strXML, "Value1", out vSoftwareKey))
					txtSoftwareKey.Text = vSoftwareKey;
				lblMessage.Text = "Success";
			}
			else
			{
				sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
				lblMessage.Text = util.ErrorPrint(vErrorCode);
			}

			sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
		}

		private void btnSetSoftwareKey_Click(object sender, EventArgs e)
		{
			string vSoftwareKey = txtSoftwareKey.Text.Trim();
			Boolean vRet;
			int vErrorCode = 0;

			lblMessage.Text = "Waiting...";
			Application.DoEvents();

			vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
			if (!vRet)
			{
				lblMessage.Text = util.gstrNoDevice;
				return;
			}

			string strXML = null;
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "SetDeviceInfoExt");
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
			sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "MachineID", Program.gMachineNumber);
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "ParamName", "softwareKey");
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "Value1", vSoftwareKey);

			vRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

			if (vRet)
			{
				lblMessage.Text = "Success";
			}
			else
			{
				sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
				lblMessage.Text = util.ErrorPrint(vErrorCode);
			}

			sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
		}

        private void btnGetDevDetailInfo_Click(object sender, EventArgs e)
        {
            Boolean vRet = true;
            int vErrorCode = 0;

            lblMessage.Text = "Waiting...";
            Application.DoEvents();

            if (!sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0)) // 0 : false
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            string strXML = null;
            sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "GetDeviceDetails");
            sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
            sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "MachineID", Program.gMachineNumber);

            vRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

            if (vRet)
            {
                txtDeviceDetailInfo.Text = strXML;

                string sMacAddr;
                sbxpc.SBXPCDLL.XML_ParseString(ref strXML, "MAC", out sMacAddr);
                lblMessage.Text = "Success! MAC Addr = " + sMacAddr;
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }
    }
}
