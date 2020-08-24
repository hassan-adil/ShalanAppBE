using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShalanAppBE.Database;
using ShalanAppBE.Repositories.Interfaces;

namespace ShalanAppBE.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected RepositoryBase(ApplicationDbContext repositoryContext) => this.RepositoryContext = repositoryContext;

        protected ApplicationDbContext RepositoryContext { get; set; }

        public async Task<T> FindAsync(object id)
        {
            return await RepositoryContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression);
        }

        public async Task CreateAsync(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.Entry(entity).State = EntityState.Modified;
            RepositoryContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            await RepositoryContext.SaveChangesAsync();
        }
    }
}
