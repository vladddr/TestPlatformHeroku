using TestPlatform.Core.Entities;
using TestPlatform.DAL.Context;

namespace TestPlatform.DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        protected readonly TestPlatformContext _context;

        public TestRepository(TestPlatformContext context)
        {
            _context = context;
        }

        public async Task<Test> AddTestsWithGroupsAsync(Test test)
        {
            // Disable groups to create many to many assotiations
            foreach(var group in test.AssignedGroups)
            {
                _context.Groups.Attach(group);
            }

            var added = await _context.Set<Test>().AddAsync(test);
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
            return test;
        }
    }
}
