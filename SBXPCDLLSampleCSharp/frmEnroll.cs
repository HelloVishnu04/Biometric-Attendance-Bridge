using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using System.Xml.Linq;

namespace BiometricAttendanceBridge
{
    public partial class frmEnroll : Form
    {
        public frmEnroll()
        {
            InitializeComponent();
        }

        int DATASIZE = (1404 + 12) / 4;
        int NAMESIZE = 54;
        int[] gTemplngEnrollData;
        Byte[] gbytEnrollData;
        Byte[] gbytEnrollData1;
        int[] gTempEnrollName;
        int glngEnrollPData;
        //        Boolean gGetState;
        ASCIIEncoding ascii;

        DataSet dsEnrolls;

        private void frmEnroll_Load(object sender, EventArgs e)
        {
            gbytEnrollData = new Byte[DATASIZE * 5];
            gbytEnrollData1 = new Byte[DATASIZE * 5];
            gTemplngEnrollData = new int[DATASIZE];
            gTempEnrollName = new int[NAMESIZE];
            ascii = new ASCIIEncoding();

            EnrollData ed = new EnrollData();
            ed.New("./");
            dsEnrolls = EnrollData.DataModule.GetEnrollDatas();

			cmbExcelType.SelectedIndex = 0;
        }

        private void cmdGetEnrollData_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vEMachineNumber;
            int vFingerNumber;
            int vPrivilege = 0;
            Boolean vRet;
            int vErrorCode = 0;
            int i;

            GCHandle gh;
            IntPtr AddrOfTemplngEnrollData;

            lblEnrollData.Text = "Enrolled Data";
            lstEnrollData.Items.Clear();
            Label2.Text = "";
            lstEnrollData.Items.Clear();
            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
            vFingerNumber = Convert.ToInt32(cmbBackupNumber.Text);
            if (vFingerNumber == 10) vFingerNumber = 15;
            vEMachineNumber = Program.gMachineNumber;

            gh = GCHandle.Alloc(gTemplngEnrollData, GCHandleType.Pinned);
            AddrOfTemplngEnrollData = gh.AddrOfPinnedObject();

            glngEnrollPData = 0;

            vRet = sbxpc.SBXPCDLL.GetEnrollData1(Program.gMachineNumber, vEnrollNumber, vFingerNumber, out vPrivilege, AddrOfTemplngEnrollData, out glngEnrollPData);
            gh.Free();

            if (vRet)
            {
                cmbPrivilege.SelectedIndex = vPrivilege;
                lblMessage.Text = "GetEnrollData OK";
                if (vFingerNumber == 11) // Card Number
                {
                    txtCardNumber.Text = Convert.ToString(glngEnrollPData, 16).ToUpper();
                }
                else if(vFingerNumber == 14) // User timezone
                {
                    txtUserTz1.Text = Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                    txtUserTz2.Text = Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                    txtUserTz3.Text = Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                    txtUserTz4.Text = Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                    txtUserTz5.Text = Convert.ToString(glngEnrollPData % 64); glngEnrollPData = glngEnrollPData / 64;
                }
                else if (vFingerNumber == 15) // Password
                {
                    txtCardNumber.Text = "";
                    while (glngEnrollPData > 0)
                    {
                        i = glngEnrollPData % 16 - 1;
                        txtCardNumber.Text = txtCardNumber.Text + Convert.ToString(i);
                        glngEnrollPData = glngEnrollPData / 16;
                    }
                }
                else if (vFingerNumber == 16) // User department
                {
                    txtDepart.Text = Convert.ToString(glngEnrollPData);
                }
                else // other
                {
                    for (i = 0; i < DATASIZE; i++)
                        lstEnrollData.Items.Add(Convert.ToString(gTemplngEnrollData[i]));
                }
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdSetEnrollData_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vEMachineNumber;
            int vFingerNumber;
            int vPrivilege;
            Boolean vRet;
            int vErrorCode = 0;

            GCHandle gh;
            IntPtr AddrOfTemplngEnrollData;


            lblMessage.Text = "Working...";
            Application.DoEvents();

            if (txtEnrollNumber.Text == "") txtEnrollNumber.Text = "0";
            if (txtCardNumber.Text == "") txtCardNumber.Text = "0";
            
            vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
            vFingerNumber = Convert.ToInt32(cmbBackupNumber.Text);
            if (vFingerNumber == 10) vFingerNumber = 15;
            vPrivilege = Convert.ToInt32(cmbPrivilege.Text);
            vEMachineNumber = Program.gMachineNumber;

            if (vFingerNumber == 11) // Card 
            {
                glngEnrollPData = Convert.ToInt32(txtCardNumber.Text, 16);
            }
            else if (vFingerNumber == 14) // User timezone
            {
                glngEnrollPData = Convert.ToInt32(txtUserTz5.Text);
                glngEnrollPData = glngEnrollPData * 64 + Convert.ToInt32(txtUserTz4.Text);
                glngEnrollPData = glngEnrollPData * 64 + Convert.ToInt32(txtUserTz3.Text);
                glngEnrollPData = glngEnrollPData * 64 + Convert.ToInt32(txtUserTz2.Text);
                glngEnrollPData = glngEnrollPData * 64 + Convert.ToInt32(txtUserTz1.Text);
            }
            else if (vFingerNumber == 15) // Password
            {
                int i = txtCardNumber.Text.Length;
                if (i > 6) i = 6;
                glngEnrollPData = 0;
                while (i > 0)
                {
                    glngEnrollPData = glngEnrollPData * 16 + Convert.ToInt16(txtCardNumber.Text.Substring(i - 1, 1)) + 1;
                    i--;
                }
            }
            else if (vFingerNumber == 16) // User department
            {
                glngEnrollPData = Convert.ToInt32(txtDepart.Text);
            }
            
            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            gh = GCHandle.Alloc(gTemplngEnrollData, GCHandleType.Pinned);
            AddrOfTemplngEnrollData = gh.AddrOfPinnedObject();

            vRet = sbxpc.SBXPCDLL.SetEnrollData1(Program.gMachineNumber, vEnrollNumber, vFingerNumber, vPrivilege, AddrOfTemplngEnrollData, glngEnrollPData);
            gh.Free();

            if (vRet)
            {
                lblMessage.Text = "SetEnrollData OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdDeleteEnrollData_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vEMachineNumber;
            int vFingerNumber;
            Boolean vRet;
            int vErrorCode = 0;

            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
            vEMachineNumber = Program.gMachineNumber;
            vFingerNumber = Convert.ToInt32(cmbBackupNumber.Text);

            vRet = sbxpc.SBXPCDLL.DeleteEnrollData(Program.gMachineNumber, vEnrollNumber, vEMachineNumber, vFingerNumber);
            if (vRet)
            {
                lblMessage.Text = "DeleteEnrollData OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdGetAllEnrollData_Click(object sender, EventArgs e)
        {
            int vEnrollNumber = 0;
            int vEMachineNumber = 0;
            int vFingerNumber = 0;
            int vPrivilege = 0;
            int vEnable = 0;
            Boolean vFlag;
            Boolean vRet;
            int vMsgRet;
            int vErrorCode = 0;
            string vStr = "";
            int i;
            string vTitle;

            DataTable dbEnrollTble;
            DataRow dbRow;
            DataSet dsChange;

            GCHandle gh;

            lstEnrollData.Items.Clear();
            vTitle = this.Text;
            Label2.Text = "";
            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vRet = sbxpc.SBXPCDLL.ReadAllUserID(Program.gMachineNumber);
            if (vRet)
            {
                lblMessage.Text = "ReadAllUserID OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
                sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
                return;
            }

            //*'*/---- Get Enroll data and save into database -------------
            Cursor = System.Windows.Forms.Cursors.WaitCursor;
            vFlag = false;


            dbEnrollTble = dsEnrolls.Tables[0];

            //            gGetState = true;

            while (true)
            {
                vRet = sbxpc.SBXPCDLL.GetAllUserID(Program.gMachineNumber, out vEnrollNumber, out vEMachineNumber, out vFingerNumber, out vPrivilege, out vEnable);
                if (!vRet) break;
                vFlag = true;
            EEE:
//                if (vFingerNumber == 10) vFingerNumber = 15;

                gh = GCHandle.Alloc(gTemplngEnrollData, GCHandleType.Pinned);
                IntPtr AddrOfTemplngEnrollData = gh.AddrOfPinnedObject();

                if (vFingerNumber >= 51)
                    continue;
                if (vFingerNumber == 50) //name only
                {
                    string vName = "";
                    vRet = sbxpc.SBXPCDLL.GetUserName1(Program.gMachineNumber, vEnrollNumber, out vName);
                    if (vRet)
                    {
                        dbRow = dbEnrollTble.NewRow();
                        dbRow["EMachineNumber"] = vEMachineNumber;
                        dbRow["EnrollNumber"] = vEnrollNumber;
                        dbRow["FingerNumber"] = vFingerNumber;
                        dbRow["Privilige"] = vPrivilege;
                        dbRow["UserName"] = vName;
                        dbRow["Password1"] = 0;
                        dbEnrollTble.Rows.Add(dbRow);
                    }
                    goto FFF;
                }
                vRet = sbxpc.SBXPCDLL.GetEnrollData1(Program.gMachineNumber, vEnrollNumber, vFingerNumber, out vPrivilege, AddrOfTemplngEnrollData, out glngEnrollPData);
				gh.Free();

                if (!vRet)
                {
                    vFlag = false;
                    vStr = "GetEnrollData";
                    sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                    vMsgRet = util.MessageBox(new IntPtr(0), util.ErrorPrint(vErrorCode) + ": Continue ?", "GetEnrollData", 4);
                    if (vMsgRet == 6/*MsgBoxResult.Yes*/)
                    {
                        goto EEE;
                    }
                    else if (vMsgRet == 7/*MsgBoxResult.Cancel*/)
                    {
                        Cursor = System.Windows.Forms.Cursors.Default;
                        sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
                        //                        gGetState = false;
                        return;
                    }
                }
                foreach (DataRow dbRow1 in dbEnrollTble.Rows)
                {
                    if ((int)dbRow1["EnrollNumber"] == vEnrollNumber)
                    {
                        if ((int)dbRow1["EMachineNumber"] == vEMachineNumber)
                        {
                            if ((int)dbRow1["FingerNumber"] == vFingerNumber)
                            {
                                lblMessage.Text = "Double ID";
                                goto FFF;
                            }
                        }
                    }
                }

                dbRow = dbEnrollTble.NewRow();
                dbRow["EMachineNumber"] = vEMachineNumber;
                dbRow["EnrollNumber"] = vEnrollNumber;
                dbRow["FingerNumber"] = vFingerNumber;
                dbRow["Privilige"] = vPrivilege;

                if (vFingerNumber == 10)
                {
                    dbRow["Password1"] = glngEnrollPData;
                }
                else if (vFingerNumber == 15)
                {
                    dbRow["Password1"] = glngEnrollPData;
                }
                else if (vFingerNumber == 11)
                {
                    dbRow["Password1"] = glngEnrollPData;
                }
                else
                {
                    dbRow["Password1"] = 0;

                    for (i = 0; i < DATASIZE; i++)
                    {
                        gbytEnrollData[i * 5] = 1;
                        if (gTemplngEnrollData[i] < 0)
                        {
                            gbytEnrollData[i * 5] = 0;
                            gTemplngEnrollData[i] = System.Math.Abs(gTemplngEnrollData[i]);
                        }
                        gbytEnrollData[i * 5 + 1] = (Byte)(gTemplngEnrollData[i] / 256 / 256 / 256);
                        gbytEnrollData[i * 5 + 2] = (Byte)((gTemplngEnrollData[i] / 256 / 256) % 256);
                        gbytEnrollData[i * 5 + 3] = (Byte)((gTemplngEnrollData[i] / 256) % 256);
                        gbytEnrollData[i * 5 + 4] = (Byte)(gTemplngEnrollData[i] % 256);
                    }

                    //dbRow("FPdata") = gbytEnrollData        '<---------- Error

                    Byte[] gbyt = new Byte[DATASIZE * 5];
                    for (i = 0; i < DATASIZE * 5; i++)
                        gbyt[i] = gbytEnrollData[i];
                    dbRow["FPdata"] = gbyt;

                }
                dbEnrollTble.Rows.Add(dbRow);

            FFF:

                lblMessage.Text = String.Format("{0:D2}", vEMachineNumber) + "-" + String.Format("{0:D2}", vEnrollNumber) + "-" + vFingerNumber;
                this.Text = String.Format("{0:D2}", vEnrollNumber);
                txtEnrollNumber.Text = Convert.ToString(vEnrollNumber);
                cmbBackupNumber.Text = Convert.ToString(vFingerNumber);
                cmbPrivilege.Text = Convert.ToString(vPrivilege);
                Application.DoEvents();
            }

            Label2.Text = "Total : " + dsEnrolls.Tables["tblEnroll"].Rows.Count;
            dsChange = dsEnrolls.GetChanges();
            EnrollData.DataModule.SaveEnrolls(dsEnrolls);

            //            gh.Free();


            //            gGetState = false; 

            vTitle = this.Text;
            Cursor = System.Windows.Forms.Cursors.Default;

            if (vFlag)
                lblMessage.Text = "GetAllUserID OK";
            else
                lblMessage.Text = vStr + ":" + util.ErrorPrint(vErrorCode);

            Application.DoEvents();
            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdSetAllEnrollData_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vEMachineNumber;
            int vFingerNumber;
            int vPrivilege;
            Boolean vRet;
            //            Boolean vFlag;
            int vErrorCode = 0;

            Byte[] vByte;
            int i;
            string vTitle;
            //            string vStr = "";


            DataTable dbEnrollTble;
            //            DataRow dbRow;
            GCHandle gh;
            int num;

            lstEnrollData.Items.Clear();
            vTitle = this.Text;
            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            //            vFlag = false;
            //            gGetState = true;
            Cursor = System.Windows.Forms.Cursors.WaitCursor;


            dbEnrollTble = dsEnrolls.Tables[0];

            num = 0;


            if (dbEnrollTble.Rows.Count == 0) goto EEE;

            foreach (DataRow dbRow in dbEnrollTble.Rows)
            {
                vEMachineNumber = (int)dbRow["EMachineNumber"];
                vEnrollNumber = (int)dbRow["EnrollNumber"];
                vFingerNumber = (int)dbRow["FingerNumber"];
                vPrivilege = (int)dbRow["Privilige"];
                glngEnrollPData = (int)dbRow["Password1"];

                num = num + 1;
                if (vFingerNumber == 50) //name only
                {
                    vRet = sbxpc.SBXPCDLL.SetUserName1(Program.gMachineNumber, vEnrollNumber,
                        dbRow["UserName"] as string);
                    goto LLL;
                }
                if (vFingerNumber < 10)
                {
                    vByte = (Byte[])dbRow["FPData"];

                    for (i = 0; i < DATASIZE; i++)
                    {
                        gTemplngEnrollData[i] = vByte[i * 5 + 1];
                        gTemplngEnrollData[i] = gTemplngEnrollData[i] * 256 + vByte[i * 5 + 2];
                        gTemplngEnrollData[i] = gTemplngEnrollData[i] * 256 + vByte[i * 5 + 3];
                        gTemplngEnrollData[i] = gTemplngEnrollData[i] * 256 + vByte[i * 5 + 4];
                        if (vByte[i * 5] == 0)
                            gTemplngEnrollData[i] = 0 - gTemplngEnrollData[i];
                    }
                }
            FFF:

                gh = GCHandle.Alloc(gTemplngEnrollData, GCHandleType.Pinned);
                IntPtr AddrOfTemplngEnrollData = gh.AddrOfPinnedObject();

                int vFingerNumber2 = vFingerNumber;
                if (vFingerNumber2 >= 0 && vFingerNumber2 <= 9 && !chkDupCheck.Checked)
                    vFingerNumber2 += 20;

                vRet = sbxpc.SBXPCDLL.SetEnrollData1(Program.gMachineNumber, vEnrollNumber, vFingerNumber2, vPrivilege, AddrOfTemplngEnrollData, glngEnrollPData);
                gh.Free();

                if (!vRet)
                {
                    //                    vFlag = false;
                    //                    vStr = "SetEnrollData";
                    sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                    int vMsgRet = util.MessageBox(new IntPtr(0), util.ErrorPrint(vErrorCode) + ": Continue ?", "SetEnrollData", 4);
                    if (vMsgRet == 6/*Yes Button*/) goto FFF;
                    if (vMsgRet == 7/*No Button*/) goto EEE;
                }

        LLL:
                lblMessage.Text = "EMachine = " + Convert.ToString(vEMachineNumber) + ", ID = " + String.Format("{0:D5}", vEnrollNumber) + ", FpNo = " + vFingerNumber + ", Count = " + num;

                this.Text = Convert.ToString(num);
                Application.DoEvents();
            }
        EEE:
            vTitle = this.Text;
            Cursor = System.Windows.Forms.Cursors.Default;
            //            gGetState = false;

            lblMessage.Text = "SetAllUserData OK";
            Application.DoEvents();

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdGetName_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vEMachineNumber;
            Boolean vRet;
            int vErrorCode = 0;
            string vName = "";


            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vEnrollNumber = 0;
            if (txtEnrollNumber.Text != "")
                vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
            vEMachineNumber = Program.gMachineNumber;

            vRet = sbxpc.SBXPCDLL.GetUserName1(Program.gMachineNumber, vEnrollNumber, out vName);
            if (vRet)
            {
                txtName.Text = vName;
                lblMessage.Text = "GetUserName OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdSetName_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vEMachineNumber;
            Boolean vRet;
            int vErrorCode = 0;
            string vName = "";


            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
            vEMachineNumber = Program.gMachineNumber;

            vName = txtName.Text;
            vRet = sbxpc.SBXPCDLL.SetUserName1(Program.gMachineNumber, vEnrollNumber, vName);
            if (vRet)
            {
                lblMessage.Text = "SetUserName OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }
        private void cmdSetNameFromTextFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            
            
            int vEnrollNumber;
//             int vEMachineNumber;
            Boolean vRet;
            int vErrorCode = 0;
            string vName = "";

            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        String[] ss = line.Split('\t');
                        if (ss.Count() != 2)
                        {
                            lblMessage.Text = "Invalid Line";
                            break;
                        }

                        vEnrollNumber = Convert.ToInt32(ss[0]);
                        vName = ss[1];
                        vRet = sbxpc.SBXPCDLL.SetUserName1(Program.gMachineNumber, vEnrollNumber, vName);
                        if (vRet)
                        {
                            lblMessage.Text = "ID: " + ss[0] + " (OK)";
                            Console.WriteLine("OK");
                        }
                        else
                        {
                            sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                            lblMessage.Text = "ID: " + ss[0] + " --- " + util.ErrorPrint(vErrorCode);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }
        private void cmdGetCompany_Click(object sender, EventArgs e)
        {
            int vEMachineNumber;
            Boolean vRet;
            int vErrorCode = 0;
            string vName = "";

            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vEMachineNumber = Program.gMachineNumber;

            vRet = sbxpc.SBXPCDLL.GetCompanyName1(Program.gMachineNumber, out vName);
            if (vRet)
            {
                txtName.Text = vName;
                lblMessage.Text = "Get Company Name OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdSetCompany_Click(object sender, EventArgs e)
        {
            int vEMachineNumber;
            Boolean vRet;
            int vErrorCode = 0;
            string vName = "";


            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vEMachineNumber = Program.gMachineNumber;

            vName = txtName.Text;
            vRet = sbxpc.SBXPCDLL.SetCompanyName1(Program.gMachineNumber, 1, vName);
            if (vRet)
            {
                lblMessage.Text = "Set Company Name OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdDeleteCompany_Click(object sender, EventArgs e)
        {
            int vEMachineNumber;
            Boolean vRet;
            int vErrorCode = 0;
            string vName = "";


            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vEMachineNumber = Program.gMachineNumber;

            vRet = sbxpc.SBXPCDLL.SetCompanyName1(Program.gMachineNumber, 0, vName);
            if (vRet)
            {
                lblMessage.Text = "Delete Company Name OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdGetEnrollInfo_Click(object sender, EventArgs e)
        {
            int vEMachineNumber = 0;
            int vEnrollNumber = 0;
            int vFingerNumber = 0;
            int vPrivilege = 0;
            int vEnable = 0;
            Boolean vRet;
            Boolean vFlag;
            int vErrorCode = 0;
            int i;

            lblEnrollData.Text = "User IDs";
            lstEnrollData.Items.Clear();
            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vRet = sbxpc.SBXPCDLL.ReadAllUserID(Program.gMachineNumber);
            if (vRet)
            {
                lblMessage.Text = "ReadAllUserID OK";
            }
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
                sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
                return;
            }

            //------ Show all enroll information ----------
            vFlag = false;
            i = 0;
            lstEnrollData.Items.Add(("No.  EnNo   EMNo   Fp   Priv  Enable Duress"));
            while (true)
            {
                vRet = sbxpc.SBXPCDLL.GetAllUserID(Program.gMachineNumber, out vEnrollNumber, out vEMachineNumber, out vFingerNumber, out vPrivilege, out vEnable);
                if (!vRet) break;
                vFlag = true;
                lstEnrollData.Items.Add((String.Format("{0:D5}", i) + "    " + String.Format("{0:D5}", vEnrollNumber) + "    " + String.Format("{0:D3}", vEMachineNumber) + "    " + String.Format("{0:D2}", vFingerNumber) + "    " + Convert.ToString(vPrivilege) + "    " + Convert.ToString(vEnable % 256) + "     " + Convert.ToString(vEnable / 256)));

                i = i + 1;
                Label2.Text = "Total : " + i;
            }

            if (vFlag)
                lblMessage.Text = "GetAllUserID OK";
            else
                lblMessage.Text = util.ErrorPrint(vErrorCode);

            sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
        }

        private void cmdEnableUser_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vEMachineNumber;
            int vFingerNumber;
            Boolean vRet;
            byte vFlag;
            int vErrorCode = 0;

            lblMessage.Text = "Working...";
            Application.DoEvents();

            vEMachineNumber = Program.gMachineNumber;
            vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text == "" ? "0" : txtEnrollNumber.Text);
            vFingerNumber = Convert.ToInt32(cmbBackupNumber.Text);
            vFlag = chkDisable.Checked ? (byte)0 : (byte)1;

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vRet = sbxpc.SBXPCDLL.EnableUser(Program.gMachineNumber, vEnrollNumber, vEMachineNumber, vFingerNumber, vFlag);
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

        private void cmdModifyPrivilege_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vEMachineNumber;
            int vFingerNumber;
            int vMachinePrivilege;
            Boolean vRet;
            int vErrorCode = 0;

            lblMessage.Text = "Working...";
            Application.DoEvents();

            vEMachineNumber = Program.gMachineNumber;
            vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
            vFingerNumber = Convert.ToInt32(cmbBackupNumber.Text);
            vMachinePrivilege = Convert.ToInt32(cmbPrivilege.Text);

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vRet = sbxpc.SBXPCDLL.ModifyPrivilege(Program.gMachineNumber, vEnrollNumber, vEMachineNumber, vFingerNumber, vMachinePrivilege);
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

        private void cmdEmptyEnrollData_Click(object sender, EventArgs e)
        {
            Boolean vRet;
            int vErrorCode = 0;

            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vRet = sbxpc.SBXPCDLL.EmptyEnrollData(Program.gMachineNumber);
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

        private void cmdClearData_Click(object sender, EventArgs e)
        {
            Boolean vRet;
            int vErrorCode = 0;

            lblMessage.Text = "Working...";
            Application.DoEvents();

            vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
            if (!vRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vRet = sbxpc.SBXPCDLL.ClearKeeperData(Program.gMachineNumber);
            if (vRet)
            {
                lblMessage.Text = "ClearKeeperData OK!";
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

        private void frmEnroll_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["frmMain"].Visible = true;
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            EnrollData.DataModule.DeleteDB();

            Label2.Text = "Total : 0";
            lblMessage.Text = "Deleted PC Database";
        }

        private void cmdModifyDuressFP_Click(object sender, EventArgs e)
        {
            int vEnrollNumber;
            int vFingerNumber;
            int vDuressSetting;
            bool bRet;
            int vErrorCode = 0;

            lblMessage.Text = "Working...";
            Application.DoEvents();

            bRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : disable
            if(!bRet)
            {
                lblMessage.Text = util.gstrNoDevice;
                return;
            }

            vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
            vFingerNumber = Convert.ToInt32(cmbBackupNumber.Text);
            vDuressSetting = Convert.ToInt32(cmbDuressSetting.Text);

            bRet = sbxpc.SBXPCDLL.ModifyDuressFP(Program.gMachineNumber,
                                       vEnrollNumber,
                                       vFingerNumber,
                                       vDuressSetting
                                      );
            if (bRet)
                lblMessage.Text = "ModifyDuressFP OK";
            else
            {
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }

            bRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : enable
        }

        private void cmdRemoteEnroll_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Working...";
            Application.DoEvents();

            int vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);
            int vFingerNumber = Convert.ToInt32(cmbBackupNumber.Text);

            string strXML = null;
            sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "RemoteEnroll");
            sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
            sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "MachineID", Program.gMachineNumber);
            sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "EnrollNumber", vEnrollNumber);
            bool bRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

            if (bRet)
            {
                string strResultCode;
                sbxpc.SBXPCDLL.XML_ParseString(ref strXML, "ResultCode", out strResultCode);
                if (strResultCode == "MenuProcessing")
                    lblMessage.Text = "Machine is now processing menu.";
                else if (strResultCode == "EnrollNumberError")
                    lblMessage.Text = "Invalid Enroll Number";
                else if (strResultCode == "AllEnrolled")
                    lblMessage.Text = "All fingerprints are enrolled for this user";
                else if (strResultCode == "DatabaseFull")
                    lblMessage.Text = "Fingerprint database is full.";
                else if (strResultCode == "Success")
                    lblMessage.Text = "Remote Enroll Started.";
                else
                    lblMessage.Text = "Unknown Error";
            }
            else
            {
                int vErrorCode;
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }
        }

        private void cmdRemoteEnrollCard_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Working...";
            Application.DoEvents();

            int vEnrollNumber = Convert.ToInt32(txtEnrollNumber.Text);

            string strXML = null;
            sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "RemoteEnrollCard");
            sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
            sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "MachineID", Program.gMachineNumber);
            sbxpc.SBXPCDLL.XML_AddLong(ref strXML, "EnrollNumber", vEnrollNumber);
            bool bRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

            if (bRet)
            {
                string strResultCode;
                sbxpc.SBXPCDLL.XML_ParseString(ref strXML, "ResultCode", out strResultCode);
                if (strResultCode == "MenuProcessing")
                    lblMessage.Text = "Machine is now processing menu.";
                else if (strResultCode == "EnrollNumberError")
                    lblMessage.Text = "Invalid Enroll Number";
                else if (strResultCode == "CardAlreadyEnrolled")
                    lblMessage.Text = "Card are already enrolled for this user";
                else if (strResultCode == "Success")
                    lblMessage.Text = "Remote Enroll(Card) Started.";
                else
                    lblMessage.Text = "Unknown Error";
            }
            else
            {
                int vErrorCode;
                sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
                lblMessage.Text = util.ErrorPrint(vErrorCode);
            }
        }

		/// <summary>
		/// EXCEL file importing
		/// </summary>
		[DllImport("excel_lib_dll_sc.dll", EntryPoint = "ProcessUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern IntPtr ProcessUserInfoXLS_sc(String FileName, String DebugFileName);
		[DllImport("excel_lib_dll_sc_ss.dll", EntryPoint = "ProcessUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern IntPtr ProcessUserInfoXLS_sc_ss(String FileName, String DebugFileName);
		[DllImport("excel_lib_dll_tc.dll", EntryPoint = "ProcessUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern IntPtr ProcessUserInfoXLS_tc(String FileName, String DebugFileName);
		[DllImport("excel_lib_dll_tc_ss.dll", EntryPoint = "ProcessUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern IntPtr ProcessUserInfoXLS_tc_ss(String FileName, String DebugFileName);
		[DllImport("excel_lib_dll_en.dll", EntryPoint = "ProcessUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern IntPtr ProcessUserInfoXLS_en(String FileName, String DebugFileName);
		[DllImport("excel_lib_dll_en_ss.dll", EntryPoint = "ProcessUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern IntPtr ProcessUserInfoXLS_en_ss(String FileName, String DebugFileName);
		[DllImport("excel_lib_dll_th.dll", EntryPoint = "ProcessUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern IntPtr ProcessUserInfoXLS_th(String FileName, String DebugFileName);
		[DllImport("excel_lib_dll_th_ss.dll", EntryPoint = "ProcessUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern IntPtr ProcessUserInfoXLS_th_ss(String FileName, String DebugFileName);

		[DllImport("excel_lib_dll_sc.dll", EntryPoint = "GenerateUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern int GenerateUserInfoXLS_sc(uint DevId, String FileName, IntPtr DbXmlUtf8Encoded);
		[DllImport("excel_lib_dll_sc_ss.dll", EntryPoint = "GenerateUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern int GenerateUserInfoXLS_sc_ss(uint DevId, String FileName, IntPtr DbXmlUtf8Encoded);
		[DllImport("excel_lib_dll_tc.dll", EntryPoint = "GenerateUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern int GenerateUserInfoXLS_tc(uint DevId, String FileName, IntPtr DbXmlUtf8Encoded);
		[DllImport("excel_lib_dll_tc_ss.dll", EntryPoint = "GenerateUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern int GenerateUserInfoXLS_tc_ss(uint DevId, String FileName, IntPtr DbXmlUtf8Encoded);
		[DllImport("excel_lib_dll_en.dll", EntryPoint = "GenerateUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern int GenerateUserInfoXLS_en(uint DevId, String FileName, IntPtr DbXmlUtf8Encoded);
		[DllImport("excel_lib_dll_en_ss.dll", EntryPoint = "GenerateUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern int GenerateUserInfoXLS_en_ss(uint DevId, String FileName, IntPtr DbXmlUtf8Encoded);
		[DllImport("excel_lib_dll_th.dll", EntryPoint = "GenerateUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern int GenerateUserInfoXLS_th(uint DevId, String FileName, IntPtr DbXmlUtf8Encoded);
		[DllImport("excel_lib_dll_th_ss.dll", EntryPoint = "GenerateUserInfoXLS", CharSet = CharSet.Unicode)]
		private static extern int GenerateUserInfoXLS_th_ss(uint DevId, String FileName, IntPtr DbXmlUtf8Encoded);
		string ProcessUserInfoXLS(string filename)
		{
			string s = filename;
			string ds = null; // @"D:\0\1.xml"; //debug only
			IntPtr r = IntPtr.Zero;

			switch (cmbExcelType.SelectedIndex)
			{
				case 0: r = ProcessUserInfoXLS_sc(s, ds); break;
				case 1: r = ProcessUserInfoXLS_sc_ss(s, ds); break;
				case 2: r = ProcessUserInfoXLS_tc(s, ds); break;
				case 3: r = ProcessUserInfoXLS_tc_ss(s, ds); break;
				case 4: r = ProcessUserInfoXLS_en(s, ds); break;
				case 5: r = ProcessUserInfoXLS_en_ss(s, ds); break;
				case 6: r = ProcessUserInfoXLS_th(s, ds); break;
				case 7: r = ProcessUserInfoXLS_th_ss(s, ds); break;
			}

			byte[] rr;
			unsafe
			{
				int len = 0;
				byte* p = (byte*)r.ToPointer();
				while (*p != 0)
				{
					len++;
					p++;
				}

				rr = new byte[len];
				p = (byte*)r.ToPointer();
				fixed (byte* p2 = &rr[0])
				{
					byte* p3 = p2;
					while (*p != 0)
					{
						*p3 = *p;
						p++;
						p3++;
					}
				}
			}

			UTF8Encoding utf8 = new UTF8Encoding();
			string xml = utf8.GetString(rr);
			return xml;
		}

		enum UserLevel
		{
			User,
			Manager,
			SuperManager,
		}
		class UserInfo
		{
			public uint Id;
			public UserLevel Level;
			public bool Enabled;
			public string Name;
			public string Department;
			public List<byte[]> finegers;
			public uint? Card;
			public uint? Password;

			public UserInfo()
			{

			}
			public UserInfo(XElement u)
			{
				Id = uint.Parse((from n in u.Elements() where n.Name == "id" select n).FirstOrDefault().Value); //Already validated

				Level = UserLevel.User;
				var e = from n in u.Elements() where n.Name == "level" select n;
				if(e.Count() > 0)
				{
					string s = e.FirstOrDefault().Value;
					if(String.Compare(s, "manager", true) == 0)
						Level = UserLevel.Manager;
					else if (String.Compare(s, "super-manager", true) == 0)
						Level = UserLevel.SuperManager;
				}

				Enabled = true;
				e = from n in u.Elements() where n.Name == "enabled" select n;
				if (e.Count() > 0)
				{
					string s = e.FirstOrDefault().Value;
					int n;
					if (int.TryParse(s, out n))
						Enabled = n != 0;
				}

				Name = null;
				e = from n in u.Elements() where n.Name == "name" select n;
				if (e.Count() > 0)
					Name = e.FirstOrDefault().Value;

				Department = null;
				e = from n in u.Elements() where n.Name == "department" select n;
				if (e.Count() > 0)
					Department = e.FirstOrDefault().Value;

				finegers = new List<byte[]>();
				e = from n in u.Elements() where n.Name == "finger" select n;
				if (e.Count() > 0)
				{
					foreach(var ee in e)
					{
						byte[] data = Convert.FromBase64String(ee.Value);
						if (data.Length == (1404 + 12))
							finegers.Add(data);
					}
				}

				Card = null;
				e = from n in u.Elements() where n.Name == "card" select n;
				if (e.Count() > 0)
				{
					string s = e.FirstOrDefault().Value;
					uint n;
					if (uint.TryParse(s, out n))
					{
						Card = n;
					}
				}

				Password = null;
				e = from n in u.Elements() where n.Name == "password" select n;
				if (e.Count() > 0)
				{
					string s = e.FirstOrDefault().Value;

					uint dwPwd = 0;
					int nShift = 0;
					foreach(var c in s)
					{
						dwPwd |= ((uint)((int)c - (int)'0' + 1) & 0x000F) << nShift;
					}

					Password = dwPwd;
				}
			}
		}
		List<UserInfo> UserInfos = new List<UserInfo>();
		Dictionary<int, UserInfo> UserInfosMap = new Dictionary<int,UserInfo>();

		void ProcessUserInfoXML(string xml)
		{
			UserInfos.Clear();

			XDocument doc = XDocument.Load(new StringReader(xml));

			if (doc.Root.Name != "user_infos")
				return;

			var q = from n in doc.Root.Elements() where n.Name == "user_info" select n;
			if(q.Count() == 0)
				throw new Exception();

			foreach (var u in q)
			{
				try
				{
					uint id = uint.Parse((from n in u.Elements() where n.Name == "id" select n).FirstOrDefault().Value); //validate id
					UserInfos.Add(new UserInfo(u));
				}
				catch
				{

				}
			}
		}

		private void cmdImportXls_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

			openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			string xml = ProcessUserInfoXLS(openFileDialog1.FileName);
			ProcessUserInfoXML(xml);

			if(UserInfos.Count > 0)
			{
				lblMessage.Text = "Available User Count = " + UserInfos.Count;
				Application.DoEvents();
				util.Sleep(1000);

				Boolean vRet;
				int vErrorCode = 0;
				vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
				if (!vRet)
				{
					lblMessage.Text = util.gstrNoDevice;
					return;
				}

				lblMessage.Text = "Deleting all user database...";
				Application.DoEvents();
				vRet = sbxpc.SBXPCDLL.EmptyEnrollData(Program.gMachineNumber);
				if (vRet)
				{
					lblMessage.Text = "Success!";
				}
				else
				{
					sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
					lblMessage.Text = util.ErrorPrint(vErrorCode);
					sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
					return;
				}

				foreach(var u in UserInfos)
				{
					string msg = "Transferring User Data, Id = " + u.Id;
					lblMessage.Text = msg;
					Application.DoEvents();

					if(u.finegers.Count > 0)
					{
						int i = 0;
						foreach(var f in u.finegers)
						{
							var gh = GCHandle.Alloc(f, GCHandleType.Pinned);
							vRet = sbxpc.SBXPCDLL.SetEnrollData1(Program.gMachineNumber,
								(int)u.Id, i + 20 /*no double check*/, (int)u.Level, gh.AddrOfPinnedObject(), 0);
							gh.Free();
							if (vRet)
							{
								lblMessage.Text = msg + ", Finger " + i + " Success!";
								Application.DoEvents();
							}
							else
							{
								sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
								lblMessage.Text = msg + ", Finger " + i + " Error : " + util.ErrorPrint(vErrorCode);
								Application.DoEvents();
							}

							i++;
						}
					}
					if (u.Card != null)
					{
						vRet = sbxpc.SBXPCDLL.SetEnrollData1(Program.gMachineNumber,
							(int)u.Id, 11, (int)u.Level, IntPtr.Zero, (int)u.Card.Value);
						if (vRet)
						{
							lblMessage.Text = msg + ", Card Success!";
							Application.DoEvents();
						}
						else
						{
							sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
							lblMessage.Text = msg + ", Card Error : " + util.ErrorPrint(vErrorCode);
							Application.DoEvents();
						}
					}
					if (u.Password != null)
					{
						vRet = sbxpc.SBXPCDLL.SetEnrollData1(Program.gMachineNumber,
							(int)u.Id, 15, (int)u.Level, IntPtr.Zero, (int)u.Password.Value);
						if (vRet)
						{
							lblMessage.Text = msg + ", Password Success!";
							Application.DoEvents();
						}
						else
						{
							sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
							lblMessage.Text = msg + ", Password Error : " + util.ErrorPrint(vErrorCode);
							Application.DoEvents();
						}
					}
					if(u.Name != null)
					{
						vRet = sbxpc.SBXPCDLL.SetUserName1(Program.gMachineNumber, (int)u.Id, u.Name);
						if (vRet)
						{
							lblMessage.Text = msg + ", Name Success!";
							Application.DoEvents();
						}
						else
						{
							sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
							lblMessage.Text = msg + ", Name Error : " + util.ErrorPrint(vErrorCode);
							Application.DoEvents();
						}
					}
					//This sample does not use Enabled, Department!
				}

				sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
				lblMessage.Text = "Success!";
			}
			else
			{
				lblMessage.Text = "Nothing Found !";
				Application.DoEvents();
			}
		}

		private void cmdExportXls_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

			saveFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 1;
			saveFileDialog1.RestoreDirectory = true;

			if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			var FileName = saveFileDialog1.FileName;

			//Getting whole user database
			{
				UserInfosMap.Clear();

				int vEnrollNumber = 0;
				int vEMachineNumber = 0;
				int vFingerNumber = 0;
				int vPrivilege = 0;
				int vEnable = 0;
				GCHandle gh;

				Boolean vRet;
				int vErrorCode = 0;
				vRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0); // 0 : false
				if (!vRet)
				{
					lblMessage.Text = util.gstrNoDevice;
					return;
				}

				lblMessage.Text = "Getting Whole User Database...";
				Application.DoEvents();
				vRet = sbxpc.SBXPCDLL.ReadAllUserID(Program.gMachineNumber);
				if (vRet)
				{
					lblMessage.Text = "ReadAllUserID OK";
					Application.DoEvents();
				}
				else
				{
					sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
					lblMessage.Text = util.ErrorPrint(vErrorCode);
					sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
					return;
				}

				while (true)
				{
					vRet = sbxpc.SBXPCDLL.GetAllUserID(Program.gMachineNumber, out vEnrollNumber, out vEMachineNumber, out vFingerNumber, out vPrivilege, out vEnable);
					if (!vRet) break;
					if (vFingerNumber >= 50) //50 - name, 51 - photo for SB3600 only
						continue;

					lblMessage.Text = "GetEnrollData ..., id = " + vEnrollNumber + ", Backup number = " + vFingerNumber;
					Application.DoEvents();

					gh = GCHandle.Alloc(gTemplngEnrollData, GCHandleType.Pinned);
					IntPtr AddrOfTemplngEnrollData = gh.AddrOfPinnedObject();

					vRet = sbxpc.SBXPCDLL.GetEnrollData1(Program.gMachineNumber, vEnrollNumber, vFingerNumber, out vPrivilege, AddrOfTemplngEnrollData, out glngEnrollPData);
					gh.Free();

					if (!vRet)
					{
						lblMessage.Text = "GetEnrollData Fail, id = " + vEnrollNumber + ", Backup number = " + vFingerNumber;
						Application.DoEvents();
						continue;
					}

					if (!UserInfosMap.ContainsKey(vEnrollNumber))
						UserInfosMap[vEnrollNumber] = new UserInfo();
					UserInfo ui = UserInfosMap[vEnrollNumber];

					ui.Id = (uint)vEnrollNumber;
					ui.Level = (UserLevel)vPrivilege;
					ui.Enabled = true;

					if (vFingerNumber == 10)
					{
						string s = ((uint)glngEnrollPData).ToString();
						uint dwPwd = 0;
						int nShift = 0;
						foreach (var c in s)
						{
							dwPwd |= ((uint)((int)c - (int)'0' + 1) & 0x000F) << nShift;
						}

						ui.Password = dwPwd;
					}
					else if (vFingerNumber == 15)
					{
						ui.Password = (uint)glngEnrollPData;
					}
					else if (vFingerNumber == 11)
					{
						ui.Card = (uint)glngEnrollPData;
					}
					else if (vFingerNumber >= 0 && vFingerNumber <= 9)
					{
						byte[] by = new byte[DATASIZE * 4];
						unsafe
						{
							fixed (byte* pby_ = &by[0])
							{
								byte* pby = pby_;
								fixed (int* pi_ = &gTemplngEnrollData[0])
								{
									int* pi = pi_;
									for (int k = 0; k < DATASIZE; k++)
									{
										*(int*)pby = *pi;
										pby += 4;
										pi++;
									}
								}
							}

						}

						if (ui.finegers == null)
							ui.finegers = new List<byte[]>();
						ui.finegers.Add(by);
					}
					else continue;

				}

				const int DEPT_COUNT = 20;
				string[] departmentNameList;
				departmentNameList = new string[DEPT_COUNT];
				lblMessage.Text = "GetDepartNames...";
				Application.DoEvents();

				bool bRet = true;
				for (int i = 0; i < DEPT_COUNT; i++)
					bRet = sbxpc.SBXPCDLL.GetDepartName(Program.gMachineNumber, i, 0, out departmentNameList[i]) && bRet;
				if (!bRet)
				{
					lblMessage.Text = "GetDepartNames fail!";
					Application.DoEvents();
					departmentNameList = null;
				}

				foreach (var ui in UserInfosMap)
				{
					lblMessage.Text = "GetUserName ..., id = " + ui.Key;
					Application.DoEvents();

					string vName = "";
					vRet = sbxpc.SBXPCDLL.GetUserName1(Program.gMachineNumber, ui.Key, out vName);
					if (vRet)
					{
						ui.Value.Name = vName;
					}
					else
					{
						lblMessage.Text = "GetUserName Fail, id = " + ui.Key;
						Application.DoEvents();
					}

					if (departmentNameList == null)
						continue;

					lblMessage.Text = "GetDepartName ..., id = " + ui.Key;
					Application.DoEvents();

					gh = GCHandle.Alloc(gTemplngEnrollData, GCHandleType.Pinned);
					IntPtr AddrOfTemplngEnrollData = gh.AddrOfPinnedObject();

					vRet = sbxpc.SBXPCDLL.GetEnrollData1(Program.gMachineNumber, ui.Key, 16, out vPrivilege, AddrOfTemplngEnrollData, out glngEnrollPData);
					gh.Free();
					if (vRet && glngEnrollPData >= 0 && glngEnrollPData < DEPT_COUNT)
					{
						ui.Value.Department = departmentNameList[glngEnrollPData];
					}
					else
					{
						lblMessage.Text = "GetDepartName Fail, id = " + ui.Key;
						Application.DoEvents();
					}
				}

				sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1); // 1 : true
				lblMessage.Text = "Success!";
			}

			//Generating XML
			{
				lblMessage.Text = "Generating XML...";

				var root = new XElement("user_infos");

				foreach (var ui in UserInfosMap)
				{
					var uroot = 
					new XElement("user_info",
						new XElement("id", ui.Value.Id),
						new XElement("level", ui.Value.Level == UserLevel.User ? "user" : (ui.Value.Level == UserLevel.Manager ? "manager" : "super-manager")),
						new XElement("enabled", (ui.Value.Enabled ? 1:0)));

					if(ui.Value.Name != null)
						uroot.Add(new XElement("name", ui.Value.Name));
					if (ui.Value.Department != null)
						uroot.Add(new XElement("department", ui.Value.Department));

					foreach(var f in ui.Value.finegers)
						uroot.Add(new XElement("finger", Convert.ToBase64String(f, Base64FormattingOptions.None)));
					if (ui.Value.Card != null)
						uroot.Add(new XElement("card", ui.Value.Card.Value));
					if (ui.Value.Password != null)
					{
						string s = "";

						uint val = ui.Value.Password.Value;
						int i = 7;
						while ((val & (0xF << i * 4)) == 0)
							i--;
						while (i >= 0) {
							var c = (val & 0x0F);
							if (c >= 1 && c <= 10)
								s = s + (char)((int)'0' + (int)c - 1);
							val >>= 4;
							i--;
						}

						uroot.Add(new XElement("password", s));
					}
					root.Add(uroot);
				}

				UTF8Encoding utf8 = new UTF8Encoding();
				var xmlString = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" + root.ToString();
				var xmlBytes = utf8.GetBytes(xmlString);

				var gh = GCHandle.Alloc(xmlBytes, GCHandleType.Pinned);
				IntPtr xmlNative = gh.AddrOfPinnedObject();
				uint DevId = 0;
				if (!uint.TryParse(txtDeviceIDforExcel.Text, out DevId))
					DevId = 0;

				int r = 0;
				switch (cmbExcelType.SelectedIndex)
				{
					case 0: r = GenerateUserInfoXLS_sc(DevId, FileName, xmlNative); break;
					case 1: r = GenerateUserInfoXLS_sc_ss(DevId, FileName, xmlNative); break;
					case 2: r = GenerateUserInfoXLS_tc(DevId, FileName, xmlNative); break;
					case 3: r = GenerateUserInfoXLS_tc_ss(DevId, FileName, xmlNative); break;
					case 4: r = GenerateUserInfoXLS_en(DevId, FileName, xmlNative); break;
					case 5: r = GenerateUserInfoXLS_en_ss(DevId, FileName, xmlNative); break;
					case 6: r = GenerateUserInfoXLS_th(DevId, FileName, xmlNative); break;
					case 7: r = GenerateUserInfoXLS_th_ss(DevId, FileName, xmlNative); break;
				}
				gh.Free();

				lblMessage.Text = (r == 0)? "Fail!" : "Success!";
			}
		}


		private void btnGetUserPeriod_Click(object sender, EventArgs e)
		{
			Boolean bRet;
			int vErrorCode = 0;
			int lUserID, lStartDate, lEndDate;
			int yy, mm, dd;
			String strXML = "";

			lblMessage.Text = "Working...";
			Application.DoEvents();

			bRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0);
			if (!bRet)
			{
				lblMessage.Text = util.gstrNoDevice;
				return;
			}

			lUserID = Convert.ToInt32(txtEnrollNumber.Text);

			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "GetUserPeriod");
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
			sbxpc.SBXPCDLL.XML_AddInt(ref strXML, "MachineID", Program.gMachineNumber);
			sbxpc.SBXPCDLL.XML_AddInt(ref strXML, "UserID", lUserID);

			bRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

			if (bRet)
			{
				chkUsePeriod.Checked = (sbxpc.SBXPCDLL.XML_ParseInt(ref strXML, "Used") != 0);
				lStartDate = sbxpc.SBXPCDLL.XML_ParseInt(ref strXML, "Start");
				lEndDate = sbxpc.SBXPCDLL.XML_ParseInt(ref strXML, "End");
				if (chkUsePeriod.Checked)
				{
					yy = lStartDate / 256 / 256;
					mm = (lStartDate - yy * 256 * 256) / 256;
					dd = lStartDate & 0xFF;
					dtPeriodFrom.Value = new DateTime(yy + 2000, mm, dd);

					yy = lEndDate / 256 / 256;
					mm = (lEndDate - yy * 256 * 256) / 256;
					dd = lEndDate & 0xFF;
					dtPeriodTo.Value = new DateTime(yy + 2000, mm, dd);
				}
				else
				{
					dtPeriodFrom.Enabled = false;
					dtPeriodTo.Enabled = false;
				}
				lblMessage.Text = "Success!";
			}
			else
			{
				sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
				lblMessage.Text = util.ErrorPrint(vErrorCode);
			}
			sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1);
		}

		private void btnSetUserPeriod_Click(object sender, EventArgs e)
		{
			Boolean bRet;
			int vErrorCode = 0;
			int lUserID;
			int lStartPeriod, lEndPeriod;
			String strXML = "";

			lblMessage.Text = "Waiting...";
			Application.DoEvents();

			bRet = sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 0);
			if (!bRet)
			{
				lblMessage.Text = util.gstrNoDevice;
				return;
			}

			lUserID = Convert.ToInt32(txtEnrollNumber.Text);

			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "REQUEST", "SetUserPeriod");
			sbxpc.SBXPCDLL.XML_AddString(ref strXML, "MSGTYPE", "request");
			sbxpc.SBXPCDLL.XML_AddInt(ref strXML, "MachineID", Program.gMachineNumber);
			sbxpc.SBXPCDLL.XML_AddInt(ref strXML, "UserID", lUserID);

			sbxpc.SBXPCDLL.XML_AddInt(ref strXML, "Used", chkUsePeriod.Checked ? 1 : 0);
			if (chkUsePeriod.Checked)
			{
				lStartPeriod = (dtPeriodFrom.Value.Year - 2000) * 256 * 256 + dtPeriodFrom.Value.Month * 256 + dtPeriodFrom.Value.Day;
				lEndPeriod = (dtPeriodTo.Value.Year - 2000) * 256 * 256 + dtPeriodTo.Value.Month * 256 + dtPeriodTo.Value.Day;
			}
			else
			{
				lStartPeriod = 1 * 256 + 1;
				lEndPeriod = 1 * 256 + 1;
			}
			sbxpc.SBXPCDLL.XML_AddInt(ref strXML, "Start", lStartPeriod);
			sbxpc.SBXPCDLL.XML_AddInt(ref strXML, "End", lEndPeriod);

			bRet = sbxpc.SBXPCDLL.GeneralOperationXML(Program.gMachineNumber, ref strXML);

			if (bRet)
			{
				lblMessage.Text = "Success!";
			}
			else
			{
				sbxpc.SBXPCDLL.GetLastError(Program.gMachineNumber, out vErrorCode);
				lblMessage.Text = util.ErrorPrint(vErrorCode);
			}
			sbxpc.SBXPCDLL.EnableDevice(Program.gMachineNumber, 1);
		}

		private void chkUsePeriod_CheckedChanged(object sender, EventArgs e)
		{
			if (chkUsePeriod.Checked)
			{
				dtPeriodFrom.Enabled = true;
				dtPeriodTo.Enabled = true;
			}
			else
			{
				dtPeriodFrom.Enabled = false;
				dtPeriodTo.Enabled = false;
			}
		}
    }
}
