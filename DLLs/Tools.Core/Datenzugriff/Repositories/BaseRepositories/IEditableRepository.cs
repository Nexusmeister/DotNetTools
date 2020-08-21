using System.Threading.Tasks;

namespace Tools.Core.Datenzugriff.Repositories.BaseRepositories
{
    public interface IEditableRepository<T> : IBaseRepository<T> where T : class
    {
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}