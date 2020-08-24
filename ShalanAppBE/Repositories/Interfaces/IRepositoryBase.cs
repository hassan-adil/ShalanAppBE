using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShalanAppBE.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<T> FindAsync(object id);

        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);


    }
}
