using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Group = TestPlatform.Core.Entities.Group;

namespace TestPlatform.DAL.EntitiesConfigurations
{
    internal class GroupEntityConfigurator : BaseEntityConfigurator<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> group)
        {
            base.Configure(group);

            group.ToTable("group")
                .HasKey(u => u.Id);

            group.Property(g => g.Name)
                .HasColumnName("naming")
                .HasMaxLength(30);

            group.HasMany(s => s.Students)
                .WithOne(g => g.Group)
                .IsRequired();

            group.HasMany(g => g.AssignedTests)
                .WithMany(t => t.AssignedGroups);
        }
    }
}
