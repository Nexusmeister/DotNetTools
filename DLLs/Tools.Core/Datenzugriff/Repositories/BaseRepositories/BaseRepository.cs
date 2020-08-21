using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Tools.Core.Datenzugriff.Repositories.BaseRepositories
{
    public class BaseRepository<T, TContext> : IBaseRepository<T> where T : class where TContext : DbContext
    {
        protected TContext Context;

        public BaseRepository(TContext context)
        {
            Context = context;
        }


        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
    }
}