using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestPlatform.Core.Entities;

namespace TestPlatform.DAL.Context
{
    public class TestPlatformContext : DbContext
    {
        public TestPlatformContext(DbContextOptions<TestPlatformContext> options) : base(options)
        {

        }

        // Data sourses accotiated with database
        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        // Apply all of Entities Configurations presented in EntitiesConfigurations folder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
