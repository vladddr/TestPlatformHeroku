using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Core.Entities;

namespace TestPlatform.DAL.EntitiesConfigurations
{
    internal class StudentEntityConfigurator : BaseEntityConfigurator<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> student)
        {
            base.Configure(student);

            student.ToTable("student")
                .HasKey(s => s.Id);

            student.Property(s => s.GroupId)
                .HasColumnName("assgined_group_id");

            student.HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .IsRequired();
        }
    }
}
