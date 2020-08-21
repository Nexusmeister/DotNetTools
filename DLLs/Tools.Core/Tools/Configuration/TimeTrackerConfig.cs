using System;
using System.IO;
using Newtonsoft.Json;
using Tools.Core.DTOs.Administration;

namespace Tools.Core.Tools.Configuration
{
    public class TimeTrackerConfig : IConfigurable<TimeTrackerConfig>
    {
        public string DatabaseConnection { get; set; }
        public EMailCredentialsDto EmailUser { get; set; }

        public TimeTrackerConfig GetConfig()
        {
            var json = File.ReadAllText(AppContext.BaseDirectory + @"\Config.json");
            return JsonConvert.DeserializeObject<TimeTrackerConfig>(json);
        }
    }
}