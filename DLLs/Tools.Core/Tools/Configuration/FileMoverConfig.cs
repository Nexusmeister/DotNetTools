using Newtonsoft.Json;
using System;
using System.IO;

namespace Tools.Core.Tools.Configuration
{
    public class FileMoverConfig : IConfigurable<FileMoverConfig>
    {
        public string QuellOrdner { get; set; }
        public string ZielOrdner { get; set; }

        [JsonIgnore]
        public Exception Error { get; set; }

        public FileMoverConfig GetConfig()
        {
            try
            {
                var configPfad = AppContext.BaseDirectory + @"\Config.json";
                if (!File.Exists(configPfad))
                {
                    var jsonToCreate = JsonConvert.SerializeObject(this);
                    using (var sw = new StreamWriter(configPfad, false))
                    {
                        sw.Write(jsonToCreate);
                        sw.Close();
                    }
                }

                var json = File.ReadAllText(configPfad);
                return JsonConvert.DeserializeObject<FileMoverConfig>(json);
            }
            catch (Exception e)
            {
                return new FileMoverConfig
                {
                    Error = e
                };
            }
        }
    }
}
