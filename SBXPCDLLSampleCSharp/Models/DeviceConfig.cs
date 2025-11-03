using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAttendanceBridge.Models
{
    public class DeviceConfig
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string ConnectionInfo { get; set; }
        public bool IsConnected { get; set; }
    }
}
