using Tools.Core.Datenzugriff.Administration.Datenzugriff.Administration;
using Tools.Core.Datenzugriff.Repositories.Administration.Interfaces;
using Tools.Core.Datenzugriff.Repositories.BaseRepositories;
using Tools.Core.Models.Administration;

namespace Tools.Core.Datenzugriff.Repositories.Administration.Implementations
{
    public class CustomizingRepository : BaseRepository<Customizing, AdministrationDbContext>, ICustomizingRepository
    {
        public CustomizingRepository(AdministrationDbContext context) : base(context)
        {
        }
    }
}