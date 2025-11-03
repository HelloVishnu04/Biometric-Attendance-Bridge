using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiometricAttendanceBridge.Models;
using System.Collections.ObjectModel;

namespace BiometricAttendanceBridge.Services
{
    public class DeviceManager
    {
        public ObservableCollection<DeviceConfig> Devices { get; set; } = new ObservableCollection<DeviceConfig>();
        public void ConnectDevices() { /* To be implemented: connection logic */ }
        public IEnumerable<AttendanceLog> FetchAttendance(DeviceConfig device) { /* To be implemented */ yield break; }
    }
}
