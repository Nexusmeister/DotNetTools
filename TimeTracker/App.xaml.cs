using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tools.Core.Datenzugriff.Repositories.Tools.TimeTracker.Implementations;
using Tools.Core.Datenzugriff.Repositories.Tools.TimeTracker.Interfaces;
using Tools.Core.Tools.Configuration;

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static Startup Startup;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var config = new TimeTrackerConfig().GetConfig();
            Startup = new Startup(config);
        }
    }
}
