using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tools.Core.Datenzugriff.Repositories.Tools.TimeTracker.Implementations;
using Tools.Core.Datenzugriff.Repositories.Tools.TimeTracker.Interfaces;
using Tools.Core.Datenzugriff.Tools.TimeTracker;
using Tools.Core.Tools.Configuration;

namespace TimeTracker
{
    public class Startup
    {
        public TimeTrackerConfig Config { get; set; }
        public static IServiceProvider ServiceProvider { get; set; }

        public Startup(TimeTrackerConfig config)
        {
            Config = config;
            var service = new ServiceCollection();
            ConfigureServices(service, new DbContextOptionsBuilder());
            ServiceProvider = service.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection service, DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            service.AddDbContext<TimeTrackerDbContext>(o => o.UseSqlServer(Config.DatabaseConnection));
            service.AddSingleton<IStundenErfassungRepository, StundenErfassungRepository>();
        }
    }
}