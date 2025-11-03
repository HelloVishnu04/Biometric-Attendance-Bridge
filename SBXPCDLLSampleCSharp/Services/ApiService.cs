using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BiometricAttendanceBridge.Models;
using BiometricAttendanceBridge.Services;

namespace BiometricAttendanceBridge.Services
{
    public class ApiService
    {
        private readonly string postUrl = "https://domain.in/admin/attendance/webhook";
        private readonly string getUrl = "https://domain.in/admin/attendance/webhook";
        private readonly ConfigurationManager configManager;
        private static readonly HttpClient client = new HttpClient();

        // Accept ConfigurationManager as parameter (don't create new one)
        public ApiService(ConfigurationManager config)
        {
            configManager = config;
        }

        public string AccessToken => configManager?.Config?.AccessToken ?? "";

        // Simple token validation (check if token is not empty)
        public async Task<bool> AuthenticateAsync()
        {
            try
            {
                // Validate that we have a token configured
                if (string.IsNullOrWhiteSpace(AccessToken))
                {
                    return false;
                }

                // Try a simple GET request to verify token works
                string url = $"{getUrl}?access-token={AccessToken}";
                var response = await client.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // Push logs, normal case (no command)
        public async Task<bool> PushLogsAsync(List<AttendanceLog> logs)
        {
            return await PushLogsWithCommandAsync(logs, null);
        }

        // New method: Push logs with command reference
        public async Task<bool> PushLogsWithCommandAsync(List<AttendanceLog> logs, string commandReference)
        {
            try
            {
                var payload = new
                {
                    access_token = AccessToken,
                    data = logs,
                    command_reference = commandReference // may be null
                };
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(postUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // Fetch pending commands via GET https://domain.in/admin/attendance/webhook?access-token={token}
        public async Task<List<PendingCommand>> GetPendingCommandsAsync()
        {
            try
            {
                string url = $"{getUrl}?access-token={AccessToken}";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<PendingCommand>>(content) ?? new List<PendingCommand>();
                }
                return new List<PendingCommand>();
            }
            catch
            {
                return new List<PendingCommand>();
            }
        }
    }
}
