using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tools.Core.Datenzugriff.Administration.Datenzugriff.Administration;
using Tools.Core.Datenzugriff.Repositories.Administration.Implementations;
using Tools.Core.Datenzugriff.Repositories.Administration.Interfaces;
using Tools.Core.Tools.Configuration;

namespace OneDriveBackup
{
    public class Startup
    {
        public OneDriveBackupConfig Config { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public Startup(OneDriveBackupConfig config)
        {
            Config = config;
            var service = new ServiceCollection();
            ConfigureServices(service, new DbContextOptionsBuilder());
            ServiceProvider = service.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection service, DbContextOptionsBuilder optionsBuilder)
        {
            service.AddDbContext<AdministrationDbContext>(o => o.UseSqlServer(Config.DatabaseConnection));

            service.AddSingleton<IStatusRepository, StatusRepository>();
            service.AddSingleton<ICustomizingRepository, CustomizingRepository>();
        }
    }
}