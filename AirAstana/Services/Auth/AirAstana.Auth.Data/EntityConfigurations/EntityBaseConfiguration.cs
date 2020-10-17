using AirAstana.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirAstana.Auth.Data.EntityConfigurations
{
    public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).HasColumnName(nameof(EntityBase.CreatedDate));
            builder.Property(x => x.IsDeleted).HasColumnName(nameof(EntityBase.IsDeleted));
            builder.Property(x => x.RowVersion).IsRowVersion();
            ConfigureEntity(builder);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
