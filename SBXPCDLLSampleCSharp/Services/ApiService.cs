using BiometricAttendanceBridge.Models;
using BiometricAttendanceBridge.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAttendanceBridge.Services
{
    public class ApiService
    {
        private readonly ConfigurationManager configManager;
        private static readonly HttpClient client = new HttpClient();

        public ApiService(ConfigurationManager config)
        {
            configManager = config;
            client.Timeout = System.TimeSpan.FromSeconds(10);
        }

        // Get API URL from config (from Settings)
        public string ApiUrl => configManager?.Config?.ApiBaseUrl ?? "https://domain.in/admin/attendance/webhook";

        // Get token from config
        public string AccessToken => configManager?.Config?.AccessToken ?? "";

        /// <summary>
        /// Authenticate with server using permanent access token
        /// Sends POST request with test_connection flag
        /// </summary>
        public async Task<bool> AuthenticateAsync(System.Action<string> logger = null)
        {
            try
            {
                logger?.Invoke("🔐 Starting API authentication...");

                if (string.IsNullOrWhiteSpace(AccessToken))
                {
                    logger?.Invoke("❌ Token is empty - please configure in Settings");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(ApiUrl))
                {
                    logger?.Invoke("❌ API URL is empty - please configure in Settings");
                    return false;
                }

                logger?.Invoke($"🔑 Token: {AccessToken.Substring(0, Math.Min(10, AccessToken.Length))}...");
                logger?.Invoke($"📍 URL: {ApiUrl}");

                // Create test connection payload
                var testPayload = new
                {
                    access_token = AccessToken,
                    test_connection = true
                };

                string json = JsonConvert.SerializeObject(testPayload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                logger?.Invoke($"📤 Sending POST request...");

                // Send POST request with timeout
                using (var cts = new System.Threading.CancellationTokenSource(System.TimeSpan.FromSeconds(5)))
                {
                    var response = await client.PostAsync(ApiUrl, content, cts.Token);

                    logger?.Invoke($"📥 Response Status: {(int)response.StatusCode} {response.StatusCode}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        logger?.Invoke($"✅ Authentication successful!");
                        logger?.Invoke($"📋 Response: {responseContent}");
                        return true;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        logger?.Invoke("❌ Unauthorized (401) - Invalid token");
                        string errorContent = await response.Content.ReadAsStringAsync();
                        logger?.Invoke($"Error details: {errorContent}");
                        return false;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        logger?.Invoke("❌ Bad Request (400)");
                        string errorContent = await response.Content.ReadAsStringAsync();
                        logger?.Invoke($"Error details: {errorContent}");
                        return false;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        logger?.Invoke("❌ Not Found (404) - Check API URL");
                        return false;
                    }
                    else
                    {
                        logger?.Invoke($"❌ Server error ({(int)response.StatusCode})");
                        string errorContent = await response.Content.ReadAsStringAsync();
                        logger?.Invoke($"Error: {errorContent}");
                        return false;
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                logger?.Invoke($"❌ Network error: {ex.Message}");
                logger?.Invoke("Check your internet connection and API URL");
                return false;
            }
            catch (System.OperationCanceledException)
            {
                logger?.Invoke("❌ Request timeout (took longer than 5 seconds)");
                logger?.Invoke("Server may be slow or unreachable");
                return false;
            }
            catch (System.Exception ex)
            {
                logger?.Invoke($"❌ Exception: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Push attendance logs to server
        /// Logs will be saved offline if server is unreachable
        /// </summary>
        public async Task<bool> PushLogsAsync(List<AttendanceLog> logs)
        {
            return await PushLogsWithCommandAsync(logs, null);
        }

        /// <summary>
        /// Push logs with command reference
        /// When server processes these logs, it will mark the command as completed
        /// </summary>
        public async Task<bool> PushLogsWithCommandAsync(List<AttendanceLog> logs, string commandReference)
        {
            try
            {
                if (logs == null || logs.Count == 0)
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(AccessToken))
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(ApiUrl))
                {
                    return false;
                }

                // Build payload
                var payload = new
                {
                    access_token = AccessToken,
                    data = logs,
                    command_reference = commandReference
                };

                string json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send POST request
                using (var cts = new System.Threading.CancellationTokenSource(System.TimeSpan.FromSeconds(10)))
                {
                    var response = await client.PostAsync(ApiUrl, content, cts.Token);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Fetch pending commands from server via GET request
        /// </summary>
        public async Task<List<PendingCommand>> GetPendingCommandsAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(AccessToken))
                {
                    return new List<PendingCommand>();
                }

                if (string.IsNullOrWhiteSpace(ApiUrl))
                {
                    return new List<PendingCommand>();
                }

                // Build GET URL with token
                string url = $"{ApiUrl}?access-token={AccessToken}";

                // Send GET request
                using (var cts = new System.Threading.CancellationTokenSource(System.TimeSpan.FromSeconds(5)))
                {
                    var response = await client.GetAsync(url, cts.Token);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<dynamic>(content);

                        if (result != null && result["data"] != null)
                        {
                            return JsonConvert.DeserializeObject<List<PendingCommand>>(
                                result["data"].ToString()
                            ) ?? new List<PendingCommand>();
                        }
                    }
                    return new List<PendingCommand>();
                }
            }
            catch
            {
                return new List<PendingCommand>();
            }
        }
    }
}
