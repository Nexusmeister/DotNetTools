using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
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
        private DispatcherTimer _dispatcherTimer;
        private TimeSpan _arbeitszeitTimer;
        private StundenerfassungsArt _erfassungsArtSelected = StundenerfassungsArt.Unbekannt;

        public TimeSpan ArbeitszeitTimer
        {
            get => _arbeitszeitTimer;
            set
            {
                if (Math.Abs(_arbeitszeitTimer.TotalSeconds - value.TotalSeconds) < 0)
                {
                    return;
                }

                _arbeitszeitTimer = value;
                OnPropertyChanged(nameof(ArbeitszeitTimer));
            }
        }

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

                _erfassungsArtSelected = value.ErfassungsArt;
                OnPropertyChanged(nameof(ErfassungsArtSelected));
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

        public DispatcherTimer DispatcherTimer
        {
            get => _dispatcherTimer;
            set
            {
                if (_dispatcherTimer == value)
                {
                    return;
                }

                _dispatcherTimer = value;
                OnPropertyChanged(nameof(DispatcherTimer));
            }
        }

        public IEnumerable<StundenerfassungsArt> ErfassungsArten =>
            Enum.GetValues(typeof(StundenerfassungsArt))
                .Cast<StundenerfassungsArt>();

        public StundenerfassungsArt ErfassungsArtSelected
        {
            get => _erfassungsArtSelected;
            set
            {
                if (_erfassungsArtSelected == value)
                {
                    return;
                }

                _erfassungsArtSelected = value;
                OnPropertyChanged(nameof(ErfassungsArtSelected));
                StundenErfassung.ErfassungsArt = value;
                OnPropertyChanged(nameof(StundenErfassung));
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
            DispatcherTimer = new DispatcherTimer(DispatcherPriority.Render);
            DispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            DispatcherTimer.Tick += (sender, args) =>
            {
                ArbeitszeitTimer = Stopwatch.Elapsed;
            };
            DispatcherTimer.Start();
        }
    }
}