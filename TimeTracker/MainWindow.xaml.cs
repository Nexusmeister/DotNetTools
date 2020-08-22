using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TimeTracker.ViewModels;
using Tools.Core.Datenzugriff.Repositories.Tools.TimeTracker.Interfaces;
using Tools.Core.Enums;
using Tools.Core.Models.Tools.TimeTracker;
using Tools.Core.Tools;

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch sw;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TimeTrackerViewModel();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (e.Cancel)
            {
                return;
            }

            if (DataContext is TimeTrackerViewModel vm && Startup.Config.Betriebsmodus == Betriebsmodus.Produktiv)
            {
                var erfassung = vm.StundenErfassung;
                EMail.VersendeMail($"Erfasste Zeit: {vm.ArbeitszeitTimer}", "[TimeTracker] Arbeitszeit wurde erfasst!");
            }
        }
    }
}
