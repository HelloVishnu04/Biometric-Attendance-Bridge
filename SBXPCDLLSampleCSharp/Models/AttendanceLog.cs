using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAttendanceBridge.Models
{
    public class AttendanceLog
    {
        public string SerialNumber { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; } // IN/OUT
    }
}
