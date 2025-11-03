using System.IO;
using Newtonsoft.Json;

namespace BiometricAttendanceBridge.Services
{
    public class ConfigurationManager
    {
        private const string ConfigFile = "config.json";
        public AppConfiguration Config { get; set; }

        public ConfigurationManager()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            if (File.Exists(ConfigFile))
            {
                var json = File.ReadAllText(ConfigFile);
                Config = JsonConvert.DeserializeObject<AppConfiguration>(json) ?? GetDefaultConfig();
            }
            else
            {
                Config = GetDefaultConfig();
                SaveConfig();
            }
        }

        private AppConfiguration GetDefaultConfig()
        {
            return new AppConfiguration
            {
                ApiBaseUrl = "https://domain.in/admin/attendance/webhook",
                AccessToken = "",
                SyncIntervalMs = 300000,
                AutoStart = false
            };
        }

        public void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(Config, Formatting.Indented);
            File.WriteAllText(ConfigFile, json);
        }
    }

    public class AppConfiguration
    {
        public string ApiBaseUrl { get; set; }
        public string AccessToken { get; set; }
        public int SyncIntervalMs { get; set; }
        public bool AutoStart { get; set; }
    }
}
