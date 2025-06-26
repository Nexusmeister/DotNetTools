using Tools.Core.Datenzugriff.Repositories.BaseRepositories;
using Tools.Core.Datenzugriff.Repositories.Tools.TimeTracker.Interfaces;
using Tools.Core.Datenzugriff.Tools.TimeTracker;
using Tools.Core.Models.Tools.TimeTracker;

namespace Tools.Core.Datenzugriff.Repositories.Tools.TimeTracker.Implementations
{
    public class StundenErfassungRepository : EditableRepository<StundenErfassung, TimeTrackerDbContext>, IStundenErfassungRepository
    {
        public StundenErfassungRepository(TimeTrackerDbContext context) : base(context)
        {
        }
    }
}