using System.Linq.Expressions;

namespace TestPlatform.Core.Specifications
{
    public interface ISpecification<TEntity>
    {
        // Criteria in suppose with that we are taking data
        Expression<Func<TEntity, bool>> Criteria { get; }

        // Include returning entities
        List<Expression<Func<TEntity, object>>> Includes { get; }

        // String Based Specification
        List<string> IncludeStrings { get; }
    }
}
