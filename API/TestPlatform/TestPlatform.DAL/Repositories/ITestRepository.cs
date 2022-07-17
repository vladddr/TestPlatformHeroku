using TestPlatform.Core.Entities;

namespace TestPlatform.DAL.Repositories
{
    public interface ITestRepository
    {
        Task<Test>AddTestsWithGroupsAsync(Test entity);
    }
}
