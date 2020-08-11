using System;
using System.IO;
using Newtonsoft.Json;
using Tools.Core.DTOs.Administration;

namespace Tools.Core.Tools.Configuration
{
    public class OneDriveBackupConfig : IConfigurable<OneDriveBackupConfig>
    {
        public string DatabaseConnection { get; set; }
        public EMailCredentialsDto EmailUser { get; set; }

        public OneDriveBackupConfig GetConfig()
        {
            var json = File.ReadAllText(AppContext.BaseDirectory + @"\Config.json");
            return JsonConvert.DeserializeObject<OneDriveBackupConfig>(json);
        }
    }
}