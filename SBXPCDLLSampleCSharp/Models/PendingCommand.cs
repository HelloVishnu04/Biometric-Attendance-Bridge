using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAttendanceBridge.Models
{
    public class PendingCommand
    {
        public string SerialNumber { get; set; }
        public string CommandText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
