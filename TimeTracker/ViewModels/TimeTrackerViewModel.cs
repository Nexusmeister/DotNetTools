using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tools.Core.Datenzugriff.Repositories.Tools.TimeTracker.Interfaces;
using Tools.Core.Enums;
using Tools.Core.Infrastructure;
using Tools.Core.Models.Tools.TimeTracker;

namespace TimeTracker.ViewModels
{
    public class TimeTrackerViewModel : BaseViewModel
    {
        private readonly IStundenErfassungRepository _stundenErfassungRepository;     
        
        private StundenErfassung _stundenErfassung;
        private Stopwatch _stopwatch;

        public TimeSpan ArbeitszeitTimer => Stopwatch.Elapsed;

        public StundenErfassung StundenErfassung
        {
            get => _stundenErfassung;
            set
            {
                if (value == null)
                {
                    return;
                }

                _stundenErfassung = value;
                OnPropertyChanged(nameof(StundenErfassung));
            }
        }

        public Stopwatch Stopwatch
        {
            get
            {
                if (_stopwatch == null)
                {
                    Stopwatch = Stopwatch.StartNew();
                }

                return _stopwatch;
            }
            set
            {
                if (value != null)
                {
                    _stopwatch = value;
                }

                OnPropertyChanged(nameof(Stopwatch));
            }
        }

        public TimeTrackerViewModel()
        {
            _stundenErfassungRepository = Startup.ServiceProvider.GetService<IStundenErfassungRepository>();
            Task.Run(async () => await ErstelleNeuenArbeitstag());

            InitialisiereTimer();
        }

        private async Task ErstelleNeuenArbeitstag()
        {
            await _stundenErfassungRepository.Insert(new StundenErfassung
            {
                BeginnArbeit = DateTime.Now,
                ErfassungsArt = StundenerfassungsArt.Arbeit // Standardmäßig gehen wir auf Arbeitsmodus
            });

            StundenErfassung = await _stundenErfassungRepository.GetAll()
                .Where(x => x.Erfassungsdatum.Equals(DateTime.Today) && x.EndeArbeit == null)
                .FirstOrDefaultAsync();
        }
        
        private void InitialisiereTimer()
        {
            Stopwatch = Stopwatch.StartNew();
        }
    }
}