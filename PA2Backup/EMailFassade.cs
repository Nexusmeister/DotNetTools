using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tools.Core.Tools;

namespace PA2Backup
{
    /// <summary>
    /// Schnittstelle für das Backup-Mailing
    /// </summary>
    public class EMailFassade
    {
        /// <summary>
        /// Bereitet Mailversand des Backup-Berichts vor
        /// </summary>
        /// <param name="targetFolders">Zielordner, die gesichert worden sind</param>
        public static void SendeMail(List<DirectoryInfo> targetFolders)
        {
            var content = "<h3>Gesicherte Ordner</h3>";
            var subject = $"Backup {DateTime.Now.ToLongDateString()} erfolgreich";
            var listeheuteErstellt = targetFolders.Where(x => x.CreationTime >= DateTime.Today);

            var directoryInfos = listeheuteErstellt.ToList();
            if (!directoryInfos.Any())
            {
                content += "<br>Zielordner ist auf dem aktuellsten Stand";
            }
            else
            {
                content = directoryInfos.Aggregate(content, (current, item) => current + $"<br> {item.Name}");
            }

            EMail.VersendeMail(content, subject);
        }
    }
}
