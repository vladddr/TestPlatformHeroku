using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Core.Entities;
using TestPlatform.Core.Enums;

namespace TestPlatform.DAL.EntitiesConfigurations
{
    internal class UserEntityConfigurator : BaseEntityConfigurator<User>
    {
        public override void Configure(EntityTypeBuilder<User> user)
        {
            base.Configure(user);

            user.ToTable("user")
                .HasKey(u => u.Id);

            user.HasAlternateKey(u => u.Login);

            user.HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(u => u.Id)
                .IsRequired();

            user.HasOne(u => u.Teacher)
                .WithOne(s => s.User)
                .HasForeignKey<Teacher>(t => t.Id)
                .IsRequired();

            user.Property(u => u.Login)
                .HasColumnName("login")
                .HasMaxLength(30)
                .IsRequired();

            user.Property(u => u.Password)
                .HasColumnName("password")
                .HasMaxLength(30)
                .IsRequired();

            user.Property(u => u.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(30)
                .IsRequired(false);

            user.Property(u => u.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(30)
                .IsRequired(false); ;

            user.Property(u => u.UserRole)
                .HasColumnName("role")
                .HasConversion(
                 r => r.ToString(),
                 s => (Role)Enum.Parse(typeof(Role), s));
        }
    }
}
