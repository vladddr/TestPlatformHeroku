using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Core.Entities;

namespace TestPlatform.DAL.EntitiesConfigurations
{
    internal class TeacherEntityConfigurator : BaseEntityConfigurator<Teacher>
    {
        public override void Configure(EntityTypeBuilder<Teacher> teacher)
        {
            base.Configure(teacher);

            teacher.ToTable("teacher")
                .HasKey(t => t.Id);

            teacher.HasMany(t => t.Tests)
                .WithOne(st => st.CreatedBy)
                .HasForeignKey(k => k.TeacherId)
                .IsRequired();
        }
    }
}
