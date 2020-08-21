using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tools.Core.Datenzugriff.Repositories.BaseRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}