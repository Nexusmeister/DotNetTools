using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tools.Core.Tools;
using Tools.Core.Tools.Configuration;

namespace PA2Backup
{
    public class Program
    {
        private static List<string> _sourceFolders;
        private static List<string> _targetFolders;
        private static List<DirectoryInfo> _infoFolders;
        public static Pa2BackupConfig Config;

        public static void Main(string[] args)
        {
            try
            {
                _sourceFolders = new List<string>();
                _targetFolders = new List<string>();
                _infoFolders = new List<DirectoryInfo>();
                Config = new Pa2BackupConfig().GetConfig();
                EMail.Credentials = Config.EMailUser;

                var sourceDir = Directory.GetDirectories(Config.QuellOrdner).ToList();
                var backupDir = Directory.GetDirectories(Config.ZielOrdner).ToList();
                foreach (var directory in sourceDir)
                {
                    _sourceFolders.Add(directory.Remove(0, Config.QuellOrdner.Length));
                }
                foreach (var directory in backupDir)
                {
                    _targetFolders.Add(directory.Remove(0, Config.ZielOrdner.Length));
                }

                var notInBackup = _sourceFolders.Except(_targetFolders).ToList();

                foreach (var folderSource in notInBackup.Select(dir => sourceDir.Where(x => x.EndsWith(dir)).ToArray()[0]))
                {
                    Copy(folderSource, Config.ZielOrdner);
                }

                EMailFassade.SendeMail(_infoFolders);
            }
            catch (Exception e1)
            {
                var fehlerpfad = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\FEHLER.txt";
                var stw = File.CreateText(fehlerpfad);
                EMail.VersendeMail($@"<h3>Es ist zum Abbruch des Tools gekommen</h3>
                                             <p>Toolname: <b>PA2Backup</b> </p>
                                             <p>Fehler: {e1}</p>
                                             <p> <a href=""file:///{fehlerpfad}"">Gehe zu Fehlertext</a></p>", 
                "[LAUFZEIT-FEHLER] PA2Backup");
                stw.Write($"Fehler in PA2Backup!!! {e1} {e1.InnerException}");
                stw.Close();
            }
        }

        /// <summary>
        /// Kopiert einen Quellordner in ein Zielverzeichnis
        /// </summary>
        /// <param name="source">Quellpfad</param>
        /// <param name="target">Zielpfad</param>
        private static void Copy(string source, string target)
        {
            var sourceDir = new DirectoryInfo(source);
            var targetDir = new DirectoryInfo(target + sourceDir.Name);
            _infoFolders.Add(targetDir);

            CopyDirectory(sourceDir, targetDir);
        }

        /// <summary>
        /// Tatsächliches rekursives Kopieren eines Ordners
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
            // Copy each file into the new directory.
            foreach (var fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
