using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Core.Entities;

namespace TestPlatform.DAL.EntitiesConfigurations
{
    internal class TestEntityConfigurator : BaseEntityConfigurator<Test>
    {
        public override void Configure(EntityTypeBuilder<Test> test)
        {
            base.Configure(test);

            test.ToTable("test")
                .HasKey(t => t.Id);

            test.Property(t => t.IsClosed)
                .HasColumnName("is_closed")
                .HasDefaultValue(false)
                .IsRequired();

            test.Property(t => t.Title)
                .HasColumnName("title")
                .HasMaxLength(30)
                .IsRequired();

            test.Property(t => t.Description)
                .HasColumnName("description")
                .HasMaxLength(255)
                .IsRequired();

            test.HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(t => t.TestId)
                .IsRequired();

            test.HasMany(t => t.AssignedGroups)
                .WithMany(g => g.AssignedTests);
        }
    }
}
