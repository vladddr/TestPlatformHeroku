using System.Linq.Expressions;

namespace TestPlatform.Core.Specifications
{
    /*
        Specification that describes rules which we need to get entity
    */
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; }
            = new List<Expression<Func<TEntity, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        public BaseSpecification()
        {
          
        }

        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        // Method that allow us to include necessary entities
        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
