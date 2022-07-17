using TestPlatform.Core.Entities;
using TestPlatform.Core.Specifications;

namespace TestPlatform.API.Services
{
    public interface IUserService
    {
        Task<object> ReadSpecefiedAsync(ISpecification<User> specification);

        Task<IEnumerable<object>> SearchAsync(ISpecification<User> specification);
    }
}
