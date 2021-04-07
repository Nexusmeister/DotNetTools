using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Tools.Core.DTOs;
using Tools.Core.Tools;
using Tools.Core.Tools.Configuration;

namespace BachelorAdmin
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var config = new BachelorAdminConfig().GetConfig();
                EMail.Credentials = config.EMailUser;

                var v = new DirectoryInfo(config.Backupquelle);
                var files = v.GetFiles().ToList();
                var aktuellesFile = files.OrderByDescending(x => x.CreationTime).ToList().FirstOrDefault();

                if (AppContext.BaseDirectory.Contains("Debug"))
                {
                    config.UnzipOrdner = AppContext.BaseDirectory + "UnzipResult";
                    if (!Directory.Exists(config.UnzipOrdner))
                    {
                        Directory.CreateDirectory(config.UnzipOrdner);
                    }
                }

                // Falls aus irgendwelchen Gründen, der Ordner im OneDrive nicht mehr existiert
                if (!Directory.Exists(config.UnzipOrdner))
                {
                    Directory.CreateDirectory(config.UnzipOrdner);
                }

                if (aktuellesFile is null)
                {
                    EMail.VersendeMail(
                        $"Quellverzeichnis ist leer! Bitte Verzeichnis prüfen! <br/>Quellpfad: {config.Backupquelle}",
                        "[BachelorAdmin] Quellverzeichnis vermutlich leer!");
                    return;
                }

                // Öffne File mit Datum
                var appdatafile = AppContext.BaseDirectory + "appdata.json";

                if (!File.Exists(appdatafile))
                {
                    var fs = File.Create(appdatafile);
                    fs.Close();
                }

                var timestamp = JsonConvert.DeserializeObject<TimestampDTO>(File.ReadAllText(appdatafile));

                var di = new DirectoryInfo(config.UnzipOrdner);
                if (di.GetFiles().Length == 0)
                {
                    ExtractFiles(config, aktuellesFile, appdatafile, null);
                    return;
                }

                if (timestamp is not null && aktuellesFile.CreationTime <= timestamp.LetztesDatum)
                {
                    // Log mit
                    //var logger = new ToolsLogger();
                    return;
                }

                ExtractFiles(config, aktuellesFile, appdatafile, timestamp);
            }
            catch (Exception e)
            {
                EMail.VersendeMail($"Fehler in Anwendung aufgetaucht: {e}", "[BachelorAdmin] Fehler in Anwendung!");
            }
        }

        private static void ExtractFiles(BachelorAdminConfig config, FileSystemInfo aktuellesFile, string appdatafile, TimestampDTO timestamp)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Temporär auskommentiert -> Muss schauen, wie die ZIP-Datei kodiert wird
            //ZipFile.ExtractToDirectory(aktuellesFile.FullName, config.UnzipOrdner, 
            //    Encoding.GetEncoding(1250, EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback), true);
            ZipFile.ExtractToDirectory(aktuellesFile.FullName, config.UnzipOrdner, true);

            var jsonoutput = JsonConvert.SerializeObject(new TimestampDTO
            {
                LetztesDatum = aktuellesFile.CreationTime
            });

            File.WriteAllText(appdatafile, jsonoutput);

            var mailinhalt = "Neue Version der Bachelorarbeit vorhanden und aktualisiert! <br/>" +
                             $"Datum: <b>{timestamp?.LetztesDatum} -> {aktuellesFile.LastWriteTime}</b>";
            EMail.VersendeMail(mailinhalt, "[BachelorAdmin] Neue Bachelorversion verfügbar!");
        }
    }
}
