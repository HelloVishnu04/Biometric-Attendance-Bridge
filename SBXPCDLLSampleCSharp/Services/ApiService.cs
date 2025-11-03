using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiometricAttendanceBridge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricAttendanceBridge.Services
{
    public class ApiService
    {
        private string apiUrl, authToken;
        public ApiService(string url, string token) { apiUrl = url; authToken = token; }

        public async Task<bool> PushAttendanceAsync(AttendanceLog log) { /* To be implemented */ return false; }
        public async Task<List<PendingCommand>> GetPendingCommandsAsync(string serial) { /* To be implemented */ return new List<PendingCommand>(); }
    }
}
