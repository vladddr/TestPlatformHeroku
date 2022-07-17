using TestPlatform.Core.Base;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TestPlatform.Core.Specifications;

namespace TestPlatform.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync(
                   Expression<Func<TEntity, bool>> filter = null,
                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> GetEntityAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification);
    }
}
