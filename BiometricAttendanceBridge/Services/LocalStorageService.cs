using System;
using System.Collections.Generic;
using System.IO;
using BiometricAttendanceBridge.Models;

namespace BiometricAttendanceBridge.Services
{
    public class LocalStorageService
    {
        private const string LogsFile = "offline_logs.csv";

        public void SaveLogs(List<AttendanceLog> logs)
        {
            try
            {
                using (var sw = new StreamWriter(LogsFile, true))
                {
                    foreach (var log in logs)
                    {
                        sw.WriteLine($"{log.SerialNumber},{log.UserId},{log.Timestamp},{log.Type}");
                    }
                }
            }
            catch { }
        }

        public List<AttendanceLog> LoadPendingLogs()
        {
            var logs = new List<AttendanceLog>();
            try
            {
                if (!File.Exists(LogsFile)) return logs;

                foreach (var line in File.ReadAllLines(LogsFile))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        logs.Add(new AttendanceLog
                        {
                            SerialNumber = parts[0],
                            UserId = int.Parse(parts[1]),
                            Timestamp = DateTime.Parse(parts[2]),
                            Type = parts[3]
                        });
                    }
                }
            }
            catch { }
            return logs;
        }

        public void ClearLogs()
        {
            try
            {
                if (File.Exists(LogsFile)) File.Delete(LogsFile);
            }
            catch { }
        }
    }
}
