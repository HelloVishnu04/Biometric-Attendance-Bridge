using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sbxpc;
using BiometricAttendanceBridge.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace BiometricAttendanceBridge.Services
{
    public class DeviceManager
    {
        public List<DeviceConfig> Devices { get; set; } = new List<DeviceConfig>();
        private const string DevicesFile = "devices.json";

        public DeviceManager()
        {
            LoadDevices();
        }

        public void LoadDevices()
        {
            if (File.Exists(DevicesFile))
            {
                var json = File.ReadAllText(DevicesFile);
                Devices = JsonConvert.DeserializeObject<List<DeviceConfig>>(json) ?? new List<DeviceConfig>();
            }
            else
            {
                // Default device
                Devices.Add(new DeviceConfig
                {
                    Id = Guid.NewGuid(),
                    Name = "School Attendance",
                    IPAddress = "192.168.1.55",
                    Port = 5005,
                    MachineNumber = 1,
                    ConnectionType = "LAN"
                });
                SaveDevices();
            }
        }

        public void SaveDevices()
        {
            var json = JsonConvert.SerializeObject(Devices, Formatting.Indented);
            File.WriteAllText(DevicesFile, json);
        }

        public async Task<bool> ConnectAsync(DeviceConfig device)  // ← Changed parameter type
        {
            return await Task.Run(() =>
            {
                try
                {
                    return SBXPCDLL.ConnectTcpip(device.MachineNumber, device.IPAddress, device.Port, 0);
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task DisconnectAsync(int machineNumber)
        {
            await Task.Run(() =>
            {
                try
                {
                    SBXPCDLL.Disconnect(machineNumber);
                }
                catch { }
            });
        }

        public async Task<List<AttendanceLog>> FetchLogsAsync(int machineNumber)
        {
            return await Task.Run(() =>
            {
                var logs = new List<AttendanceLog>();
                try
                {
                    if (SBXPCDLL.ReadGeneralLogData(machineNumber, 0))
                    {
                        int tMachineNumber, enrollNumber, eMachineNumber, verifyMode, year, month, day, hour, minute, second;

                        while (SBXPCDLL.GetGeneralLogData(machineNumber, out tMachineNumber, out enrollNumber,
                            out eMachineNumber, out verifyMode, out year, out month, out day, out hour, out minute, out second))
                        {
                            logs.Add(new AttendanceLog
                            {
                                SerialNumber = $"Device_{machineNumber}",
                                UserId = enrollNumber,
                                Timestamp = new DateTime(year, month, day, hour, minute, second),
                                Type = verifyMode == 0 ? "IN" : "OUT"
                            });
                        }
                    }
                }
                catch { }
                return logs;
            });
        }
    }
}
