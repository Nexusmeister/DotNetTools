using System;
using System.IO;
using Newtonsoft.Json;
using Tools.Core.DTOs.Administration;
using Tools.Core.Enums;

namespace Tools.Core.Tools.Configuration
{
    public class TimeTrackerConfig : IConfigurable<TimeTrackerConfig>
    {
        public string DatabaseConnection { get; set; }
        public EMailCredentialsDto EmailUser { get; set; }
        public Betriebsmodus Betriebsmodus { get; set; }

        public TimeTrackerConfig GetConfig()
        {
            var json = File.ReadAllText(AppContext.BaseDirectory + @"\Config.json");
            var config = JsonConvert.DeserializeObject<TimeTrackerConfig>(json);

            config.Betriebsmodus = AppDomain.CurrentDomain.BaseDirectory.Contains(@"bin\Debug") ? Betriebsmodus.Debug : Betriebsmodus.Produktiv;
            return config;
        }
    }
}