using AirAstana.Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirAstana.Flights.Data.EntityConfigurations
{
    public class LocationEntityConfiguration : EntityBaseConfiguration<LocationEntity>
    {
        public override void ConfigureEntity(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.Ignore(x => x.LocationTimeZone);
        }
    }
}
