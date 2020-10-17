using AirAstana.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirAstana.Auth.Data.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(UserEntity.RefreshTokens));
            // EF access the RefreshTokens collection property through its backing field.
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
