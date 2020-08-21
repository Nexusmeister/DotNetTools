using System;
using System.Diagnostics;
using Tools.Core.Infrastructure;
using Tools.Core.Models.Tools.TimeTracker;

namespace TimeTracker.ViewModels
{
    public class TimeTrackerViewModel : BaseViewModel
    {
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

        public TimeTrackerViewModel(StundenErfassung erfassung)
        {
            StundenErfassung = erfassung;
        }
    }
}