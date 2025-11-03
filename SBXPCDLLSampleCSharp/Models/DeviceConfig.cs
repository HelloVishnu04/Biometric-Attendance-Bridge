using System;

namespace BiometricAttendanceBridge.Models
{
    public class DeviceConfig
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int MachineNumber { get; set; }
        public string ConnectionType { get; set; }
    }

    public class AttendanceLog
    {
        public string SerialNumber { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
    }


    public class ApiAuthResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class PendingCommand
    {
        public string SerialNumber { get; set; }
        public string CommandText { get; set; }
        public string CommandReference { get; set; } // <-- Unique ref from server
        public DateTime CreatedAt { get; set; }
    }

}
