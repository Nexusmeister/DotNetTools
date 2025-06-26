using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using Tools.Core.Tools;
using Tools.Core.Tools.Configuration;

namespace FileMover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true)
                .Build();

            var aufgaben = config.GetSection("aufgaben").Get<List<Aufgabe>>();

            foreach (var aufgabe in aufgaben)
            {
                if (string.IsNullOrWhiteSpace(aufgabe.Quelle) || string.IsNullOrWhiteSpace(aufgabe.Ziel))
                {
                    Environment.Exit(1);
                }

                var isDirectory = IsDirectory(aufgabe.Quelle);

                if (isDirectory is null)
                {
                    Environment.Exit(1);
                }

                DirectoryCopy(aufgabe.Quelle, aufgabe.Ziel, true);
            }
            //var config = new FileMoverConfig().GetConfig();
            //var logger = new ToolsLogger();
            //if (string.IsNullOrWhiteSpace(config.QuellOrdner) || string.IsNullOrWhiteSpace(config.ZielOrdner))
            //{
            //    Environment.Exit(1);
            //}

            //DirectoryCopy(config.QuellOrdner, config.ZielOrdner, true);
        }

        private static bool? IsDirectory(string aufgabeQuelle)
        {
            var dir = new DirectoryInfo(aufgabeQuelle);
            if (!FileOrDirectoryExists(aufgabeQuelle))
            {
                return null;
            }

            return File.GetAttributes(aufgabeQuelle).HasFlag(FileAttributes.Directory);
        }

        private static bool FileOrDirectoryExists(string name)
        {
            return (Directory.Exists(name) || File.Exists(name));
        }

        private static void DirectoryCopy(string quellPfad, string zielPfad, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            var quelle = new DirectoryInfo(quellPfad);

            if (!quelle.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + quellPfad);
            }

            var dirs = quelle.EnumerateDirectories();

            // If the destination directory doesn't exist, create it.       
            if (!Directory.Exists(zielPfad))
            {
                Directory.CreateDirectory(zielPfad);
            }

            // Get the files in the directory and copy them to the new location.
            var files = quelle.EnumerateFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(zielPfad, file.Name);
                file.CopyTo(tempPath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(zielPfad, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }
}
