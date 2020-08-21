using System;
using Tools.Core.Infrastructure;
using Tools.Core.Models.Tools.TimeTracker;

namespace TimeTracker.ViewModels
{
    public class TimeTrackerViewModel : BaseViewModel
    {
        private TimeSpan _arbeitszeitTimer;
        private StundenErfassung _stundenErfassung;

        public TimeSpan ArbeitszeitTimer
        {
            get => _arbeitszeitTimer;
            set
            {
                if (value.TotalSeconds <= _arbeitszeitTimer.TotalSeconds)
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
            }
        }
    }
}