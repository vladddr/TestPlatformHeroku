using Microsoft.EntityFrameworkCore;
using TestPlatform.Core.Base;
using TestPlatform.Core.Specifications;

namespace TestPlatform.DAL
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /*
           The method returns modified query in order with spec         
        */
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> speceficaion)
        {
            var query = inputQuery;

            // Criterias aggeregate
            if (speceficaion.Criteria != null)
            {
                query = query.Where(speceficaion.Criteria);
            }

            // Includes aggregate
            query = speceficaion.Includes.Aggregate(query, (current, include) => current.Include(include));

            // Include any string-based include statements
            query = speceficaion.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            return query;
        }
    }
}
