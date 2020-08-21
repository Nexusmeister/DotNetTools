using Tools.Core.Datenzugriff.Administration.Datenzugriff.Administration;
using Tools.Core.Datenzugriff.Repositories.Administration.Interfaces;
using Tools.Core.Datenzugriff.Repositories.BaseRepositories;
using Tools.Core.Models.Administration;

namespace Tools.Core.Datenzugriff.Repositories.Administration.Implementations
{
    public class StatusRepository : BaseRepository<Status, AdministrationDbContext>, IStatusRepository
    {
        public StatusRepository(AdministrationDbContext context) : base(context)
        {
        }
    }
}