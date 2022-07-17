using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TestPlatform.Core.Base;
using TestPlatform.Core.Specifications;
using TestPlatform.DAL.Context;

namespace TestPlatform.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly TestPlatformContext _context;

        public GenericRepository(TestPlatformContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var added = await _context.Set<TEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

            var navigationProps = added.CurrentValues.EntityType.GetDeclaredNavigations();

            if (navigationProps != null)
            {
                foreach (var prop in navigationProps)
                {
                    // load all navigations
                    await added.Navigation(prop.Name).LoadAsync();
                }
            }

            // return added entity
            return entity;  
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (include != null)
            {
                query = include(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exist = await _context.Set<TEntity>().FindAsync(id);

            if (exist == null)
            {
                return false;
            }

            _context.Set<TEntity>().Remove(exist);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var exist = await _context.Set<TEntity>()
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (exist == null)
            {
                return null;
            }

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetEntityAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            // Returning the Query with assigned specification
            return SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), specification);
        }
    }
}
