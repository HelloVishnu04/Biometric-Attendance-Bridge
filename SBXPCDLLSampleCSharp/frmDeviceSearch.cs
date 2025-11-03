using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace BiometricAttendanceBridge
{
    public partial class frmDeviceSearch : Form
    {
        public frmDeviceSearch()
        {
            InitializeComponent();
        }

        private void frmDeviceSearch_Closed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["frmMain"].Visible = true;
            ((frmMain)Application.OpenForms["frmMain"]).btnSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            txtResult.Text += "Prefix : " + txtProductName.Text + "\r\n";
            txtResult.Text += "Device Searching ............\r\n\r\n"; Application.DoEvents(); util.Sleep(300);
     
            btnSearch.Enabled = false;

            UInt32 duration = Convert.ToUInt32(txtDuration.Text);

            my_util.DeviceDiscoverRequest req = new my_util.DeviceDiscoverRequest(txtProductName.Text);

            UdpClient sock = new UdpClient();
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), (int)my_util.DEVICE_DISCOVER_PORT);

            sock.Client.ReceiveTimeout = 1000;

            byte[] data = req.toBytes();

            // txtResult.Text += "------> Send Req Packet\r\n"; Application.DoEvents();
            sock.Send(data, data.Length, iep);

            /////////////////////////////////////////////////////////////////////
            IPEndPoint from = new IPEndPoint(IPAddress.Any, 0);

            byte[] data_recv = new byte[my_util.DeviceDiscoverResponse.getSize()];

            Int32 dwTime = Environment.TickCount;
            int count = 0;

            do {
                try
                {
                    data_recv = sock.Receive(ref from);
                    my_util.DeviceDiscoverResponse res = new my_util.DeviceDiscoverResponse(data_recv);

                    if (res.is_magic_valid())
                    {
                        FoundDevice(res);
                        count++;
                    }
                    else
                        txtResult.Text += "xxx UnMatched xxx\r\n";
                }
                catch (Exception)
                {

                }
            } while (Environment.TickCount - dwTime < duration);

            sock.Close();

            txtResult.Text += "\r\n===== Search Finished. =====\r\n";
            txtResult.Text += string.Format("Found Devices : {0} \r\n", count);
            
            btnSearch.Enabled = true;
        }

        private void FoundDevice(my_util.DeviceDiscoverResponse res)
        {
            txtResult.Text += "=== Device Found ===\r\n";
            txtResult.Text += "   ProductName : " + res.ProductName + "\r\n";
            txtResult.Text += "     Device ID : " + Convert.ToString(res.dwId) + "\r\n";
            txtResult.Text += "    IP Address : " + my_util.UInt32_to_IPstr(res.dwIp) + "\r\n";
            txtResult.Text += "          Port : " + Convert.ToString(res.wPort) + "\r\n";
            txtResult.Text += "    SubnetMask : " + my_util.UInt32_to_IPstr(res.dwSubnetMask) + "\r\n";
            txtResult.Text += "DefaultGateway : " + my_util.UInt32_to_IPstr(res.dwDefaultGateway) + "\r\n";
            txtResult.Text += "      Use DHCP : " + (res.bUseDHCP == 0 ? "FALSE" : "TRUE") + "\r\n";

            Application.DoEvents();
        }
    }
}

public class my_util
{
    public const UInt32 DEVICE_DISCOVER_PORT = 20567;

    private const UInt32 DEVDISCOVER_REQUEST_MAGIC1 = 0x0c58380d;
    private const UInt32 DEVDISCOVER_REQUEST_MAGIC2 = 0xea8b42b2;
    private const UInt32 DEVDISCOVER_RESPONSE_MAGIC1 = 0xaa8fcb84;
    private const UInt32 DEVDISCOVER_RESPONSE_MAGIC2 = 0x05fece87;

    private const byte ProductNameLen_Max = 16;

    ////////////////////////////////////////////////////////////////////////////////////////////
    public class DeviceDiscoverRequest
    {
        public UInt32 magic1;
        public UInt32 magic2;
        public string ProductNamePrefix;      // 16bytes
        //public UInt32 reserved[2];

        public static int getSize()
        {
            return 4 + 4 + 16 + 4 * 2;
        }

        public DeviceDiscoverRequest(string prefix)
        {
            magic1 = DEVDISCOVER_REQUEST_MAGIC1;
            magic2 = DEVDISCOVER_REQUEST_MAGIC2;
            ProductNamePrefix = prefix;
        }

        public byte[] toBytes()
        {
            using (var buf = new MemoryStream())
            using (var w = new BinaryWriter(buf))
            {
                w.Write((UInt32)magic1);
                w.Write((UInt32)magic2);
                w.Write(my_util.string_to_utf8_nts(ProductNamePrefix, ProductNameLen_Max));
                w.Write((UInt32)0);
                w.Write((UInt32)0);
                return buf.ToArray();
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////
    public class DeviceDiscoverResponse
    {
        public UInt32 magic1;
        public UInt32 magic2;
        public string ProductName;      // 16bytes

        public UInt32 dwId;
        public UInt32 dwIp;
        public UInt32 dwSubnetMask;
        public UInt32 dwDefaultGateway;

        public UInt16 wPort;
        public UInt16 bUseDHCP;

        //public UInt32 reserved[32];

        public static int getSize()
        {
            return 4 + 4 + 16 + 4 * 5 + 4 * 32;
        }

        public DeviceDiscoverResponse(byte[] data)
        {
            using (var buf = new MemoryStream(data))
            using (var r = new BinaryReader(buf))
            {
                magic1 = r.ReadUInt32();
                magic2 = r.ReadUInt32();
                ProductName = my_util.utf8_nts_to_string(r.ReadBytes(ProductNameLen_Max));

                dwId = r.ReadUInt32();
                dwIp = r.ReadUInt32();
                dwSubnetMask = r.ReadUInt32();
                dwDefaultGateway = r.ReadUInt32();
                wPort = r.ReadUInt16();
                bUseDHCP = r.ReadUInt16();
            }
        }
        
        public bool is_magic_valid()
        {
            return (magic1 == DEVDISCOVER_RESPONSE_MAGIC1) &&
                (magic2 == DEVDISCOVER_RESPONSE_MAGIC2);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////
    public static string utf8_nts_to_string(byte[] chars)
    {
        int len;
        for (len = 0; len < chars.Length; ++len)
            if (chars[len] == 0)
                break;

        return Encoding.UTF8.GetString(chars, 0, len);
    }
    public static byte[] string_to_utf8_nts(string str, int len)
    {
        byte[] utf8 = (str != null) ? Encoding.UTF8.GetBytes(str) : new byte[0];

        byte[] result = new byte[len];
        int effective = Math.Min(utf8.Length, len);
        for (int i = 0; i < effective; ++i)
            result[i] = utf8[i];
        for (int i = effective; i < len; ++i)
            result[i] = 0;

        return result;
    }

    public static string UInt32_to_IPstr(UInt32 ip)
    {
        return string.Format("{0}.{1}.{2}.{3}",
            (ip >> 24) & 0xFF,
            (ip >> 16) & 0xFF,
            (ip >> 8) & 0xFF,
            (ip >> 0) & 0xFF);
    }
}
