using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tools.Core.Datenzugriff.Administration.Datenzugriff.Administration;
using Tools.Core.Tools;
using Tools.Core.Tools.Configuration;

namespace OneDriveBackup
{
    class Program
    {
        private static OneDriveBackupConfig _config;
        private static Startup _startup;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //_config = new OneDriveBackupConfig().GetConfig();
            //_startup = new Startup(_config);
            
            //var context = _startup.ServiceProvider.GetService<AdministrationDbContext>();
            //var xqAsQueryable = context.Customizing.AsQueryable();
            //var res = xqAsQueryable.Where(x => x.Id > 0).ToList();

            //EMail.Credentials = _config.EmailUser;
            Console.ReadKey();
        }
    }
}
