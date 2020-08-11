using System;
using System.IO;
using Newtonsoft.Json;
using Tools.Core.DTOs.Administration;

namespace Tools.Core.Tools.Configuration
{
    public class Pa2BackupConfig : IConfigurable<Pa2BackupConfig>
    {
        public string QuellOrdner { get; set; }
        public string ZielOrdner { get; set; }

        [JsonProperty("emailUser")]
        public EMailCredentialsDto EMailUser { get; set; }

        public Pa2BackupConfig GetConfig()
        {
            var json = File.ReadAllText(AppContext.BaseDirectory + @"\Config.json");
            return JsonConvert.DeserializeObject<Pa2BackupConfig>(json);
        }
    }
}