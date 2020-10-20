using AirAstana.Flights.Core.Models.Locations;
using AirAstana.Flights.Domain.Entities;

namespace AirAstana.Flights.Core.Mappers
{
    public static class LocationMapper
    {
        public static LocationEntity ToEntity(this Location location)
        {
            if (location == null) return null;

            return new LocationEntity
            {
                City = location.City,
                Country = location.Country,
                CountryCode = location.CountryCode,
                TimeZoneId = location.TimeZoneId,
                State = location.State
            };
        }

        public static Location ToModel(this LocationEntity location)
        {
            if (location == null) return null;

            return new Location
            {
                City = location.City,
                Country = location.Country,
                CountryCode = location.CountryCode,
                TimeZoneId = location.TimeZoneId,
                State = location.State
            };
        }
    }
}
