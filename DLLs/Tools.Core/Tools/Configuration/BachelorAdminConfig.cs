using System;
using System.IO;
using Newtonsoft.Json;
using Tools.Core.DTOs.Administration;

namespace Tools.Core.Tools.Configuration
{
    public class BachelorAdminConfig : IConfigurable<BachelorAdminConfig>
    {
        public string Backupquelle { get; set; }
        public EMailCredentialsDto EMailUser { get; set; }
        public string UnzipOrdner { get; set; }


        public BachelorAdminConfig GetConfig()
        {
            var json = File.ReadAllText(AppContext.BaseDirectory + @"\Config.json");
            return JsonConvert.DeserializeObject<BachelorAdminConfig>(json);
        }
    }
}