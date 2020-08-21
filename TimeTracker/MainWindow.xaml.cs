using System;
using System.Collections.Generic;
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

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IStundenErfassungRepository _stundenErfassungRepository;

        private Stopwatch sw;

        public MainWindow()
        {
            InitializeComponent();
            _stundenErfassungRepository = Startup.ServiceProvider.GetService<IStundenErfassungRepository>();

            _ = ErstelleNeuenArbeitstag();
            StarteArbeitsTimer();
        }


        private async Task ErstelleNeuenArbeitstag()
        {
            await _stundenErfassungRepository.Insert(new StundenErfassung
            {
                BeginnArbeit = DateTime.Now,
                ErfassungsArt = StundenerfassungsArt.Arbeit
            });

            var erfassung =  await _stundenErfassungRepository.GetAll()
                .Where(x => x.Erfassungsdatum.Equals(DateTime.Today) && x.EndeArbeit == null)
                .FirstOrDefaultAsync();

            DataContext = new TimeTrackerViewModel(erfassung);
        }

        private void StarteArbeitsTimer()
        {
            if (DataContext is TimeTrackerViewModel vm)
            {
                _ = vm.ArbeitszeitTimer;
            }
            
        }
    }
}
