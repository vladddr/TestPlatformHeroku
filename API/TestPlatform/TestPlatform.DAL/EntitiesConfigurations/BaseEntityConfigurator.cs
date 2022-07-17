using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Core.Base;

namespace TestPlatform.DAL.EntitiesConfigurations
{
    internal class BaseEntityConfigurator<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnName("entity_id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(b => b.UpdateDatetime)
                .HasColumnName("updated_datetype")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();
        }
    }
}
