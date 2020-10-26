using AirAstana.Flights.Api.Models.Locations;
using AirAstana.Flights.Core.Models.Locations;

namespace AirAstana.Flights.Api.Mappers
{
    public static class LocationMapper
    {
        public static LocationModel ToApiModel(this Location location)
        {
            if (location == null) return null;

            return new LocationModel
            {
                Id = location.Id,
                City = location.City,
                Country = location.Country,
                CountryCode = location.CountryCode,
                TimeZoneId = location.TimeZoneId,
                State = location.State
            };
        }

        public static Location ToCoreModel(this LocationModel location)
        {
            if (location == null) return null;

            return new Location
            {
                Id = location.Id,
                City = location.City,
                Country = location.Country,
                CountryCode = location.CountryCode,
                TimeZoneId = location.TimeZoneId,
                State = location.State
            };
        }
    }
}
