using AirAstana.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AirAstana.Auth.Data.EntityConfigurations
{
    public class RefreshTokenEntityConfiguration : EntityBaseConfiguration<RefreshTokenEntity>
    {
        public override void ConfigureEntity(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
        }
    }
}
