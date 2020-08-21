using System;
using Tools.Core.Models.Tools.TimeTracker;

namespace TimeTracker.ViewModels
{
    public class TimeTrackerViewModel
    {
        public TimeSpan ArbeitszeitTimer { get; set; }
        public StundenErfassung StundenErfassung { get; set; }
    }
}