using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tools.Core.Datenzugriff.Repositories.BaseRepositories
{
    public class EditableRepository<T, TContext> : BaseRepository<T, TContext>, IEditableRepository<T> where T : class where TContext : DbContext
    {
        public EditableRepository(TContext context) : base(context)
        {
        }

        public async Task<int> Delete(T entity)
        {
            Context.Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Insert(T entity)
        {
            await Context.AddAsync(entity);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            Context.Update(entity);
            return await Context.SaveChangesAsync();
        }
    }
}