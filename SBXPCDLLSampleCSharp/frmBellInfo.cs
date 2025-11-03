using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace SBXPCDLLSampleCSharp
{
    public partial class frmBellInfo : Form
    {
        public frmBellInfo()
        {
            InitializeComponent();
        }

        const int MAX_BELLCOUNT = 42;
		int[] BellInfo;

		private void frmBellInfo_Load(object sender, EventArgs e)
		{
			BellInfo = new int[MAX_BELLCOUNT * 4];
			dtStart.ShowUpDown = true;

			for (int i = 0; i < MAX_BELLCOUNT; i++)
			{
				BellInfo[i * 4] = 0;
				BellInfo[i * 4 + 1] = 0;
				BellInfo[i * 4 + 2] = 0;
				BellInfo[i * 4 + 3] = 0;
			}
			DrawBellInfo();
		}
		private void DrawBellInfo()
		{
			string itemString = "";
			lstTimeZone.Items.Clear();
			int valid, startHour, startMinute, weekDay;
			for (int i = 0; i < MAX_BELLCOUNT; i++)
			{
				valid = BellInfo[i * 4];
				startHour = BellInfo[i * 4 + 1];
				startMinute = BellInfo[i * 4 + 2];
				weekDay = BellInfo[i * 4 + 3];

				itemString = "[" + String.Format("{0:D2} ] ", i);
				itemString += "[VALID] " + String.Format("{0:D1} ", valid);
				itemString += "[TIME] " + String.Format("{0:D2}:{1:D2} ", startHour, startMinute);
				itemString += "[WEEKDAY] " + String.Format("{0:D1} ", weekDay);
				lstTimeZone.Items.Add(itemString);
			}
		}

        private void cmdRead_Click(object sender, EventArgs e)
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
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "GetBellTime42");
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
			sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "MachineID", Program.gMachineNumber);

			vRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

            if (vRet)
            {
				txtBellCount.Text = Convert.ToString(sbxpc.SBXPCDLL.XML_ParseLong(ref strXML, "BellRingTimes"));
				txtBellPeriod.Text = Convert.ToString(sbxpc.SBXPCDLL.XML_ParseLong(ref strXML, "BellPeriod"));

				for (int i = 0; i < MAX_BELLCOUNT; i++)
				{
					BellInfo[i * 4] = sbxpc.SBXPCDLL.XML_ParseLong(ref strXML, String.Format("BellValid_{0:D2}", i));
					BellInfo[i * 4 + 1] = sbxpc.SBXPCDLL.XML_ParseLong(ref strXML, String.Format("BellHour_{0:D2}", i));
					BellInfo[i * 4 + 2] = sbxpc.SBXPCDLL.XML_ParseLong(ref strXML, String.Format("BellMin_{0:D2}", i));
					BellInfo[i * 4 + 3] = sbxpc.SBXPCDLL.XML_ParseLong(ref strXML, String.Format("BellDay_{0:D2}", i));
				}
				DrawBellInfo();

				lblMessage.Text = "Success!";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdWrite_Click(object sender, EventArgs e)
        {
            Boolean vRet;
            int vErrorCode = 0;

            lblMessage.Text = "Waiting...";
            Application.DoEvents();

            if (!sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0)) // 0 : false
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

			string strXML = null;
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "SetBellTime42");
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
			sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "MachineID", Program.gMachineNumber);

			sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "BellRingTimes", Convert.ToInt32(txtBellCount.Text));
			sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "BellPeriod", Convert.ToInt32(txtBellPeriod.Text));
			for (int i = 0; i < MAX_BELLCOUNT; i++)
			{
				sbxpc.SBXPCDLL.XML_AddLong(ref strXML, String.Format("BellValid_{0:D2}", i), BellInfo[i * 4]);
				sbxpc.SBXPCDLL.XML_AddLong(ref strXML, String.Format("BellHour_{0:D2}", i), BellInfo[i * 4 + 1]);
				sbxpc.SBXPCDLL.XML_AddLong(ref strXML, String.Format("BellMin_{0:D2}", i), BellInfo[i * 4 + 2]);
				sbxpc.SBXPCDLL.XML_AddLong(ref strXML, String.Format("BellDay_{0:D2}", i), BellInfo[i * 4 + 3]);
			}

			vRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

            if (vRet)
            {
                lblMessage.Text = "Success!";
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
        }

		private void lstTimeZone_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstTimeZone.SelectedIndex == -1)
				return;

			int index = lstTimeZone.SelectedIndex;

			chkUsed.Checked = BellInfo[index * 4] != 0;
			dtStart.Value = new DateTime(2000, 1, 1,         // Don't care year/month/date
											BellInfo[index * 4 + 1],
											BellInfo[index * 4 + 2],
											0
										);
			cmbWeekday.SelectedIndex = BellInfo[index * 4 + 3];
		}

		private void cmdUpdate_Click(object sender, EventArgs e)
		{
            if (lstTimeZone.SelectedIndex == -1)
                return;

            int index = lstTimeZone.SelectedIndex;

			BellInfo[index * 4] = chkUsed.Checked ? 1 : 0;
			BellInfo[index * 4 + 1] = dtStart.Value.Hour;
            BellInfo[index * 4 + 2] = dtStart.Value.Minute;
            BellInfo[index * 4 + 3] = cmbWeekday.SelectedIndex;
			DrawBellInfo();
		}

		private void frmBellInfo_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.OpenForms["frmMain"].Visible = true;
		}
    }
}
