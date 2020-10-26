using System.Linq;
using AirAstana.Flights.Api.Models.Flights;
using AirAstana.Flights.Core.Models.Flights;

namespace AirAstana.Flights.Api.Mappers
{
    public static class FlightMapper
    {
        public static Flight ToCoreModel(this FlightModel flight)
        {
            if (flight == null) return null;

            return new Flight
            {
                Id = flight.Id,
                DestinationId = flight.DestinationId,
                Destination = flight.Destination.ToCoreModel(),
                FlightNumber = flight.FlightNumber,
                SourceId = flight.SourceId,
                Source = flight.Source.ToCoreModel()
            };
        }

        public static FlightModel ToApiModel(this Flight flight, bool mapFlightSchedules = true)
        {
            if (flight == null) return null;

            var result = new FlightModel
            {
                Id = flight.Id,
                DestinationId = flight.DestinationId,
                Destination = flight.Destination.ToApiModel(),
                FlightNumber = flight.FlightNumber,
                SourceId = flight.SourceId,
                Source = flight.Source.ToApiModel(),
            };

            if (mapFlightSchedules) result.Schedules = flight.Schedules?.Select(x => x?.ToApiModel(false)).ToList();

            return result;
        }
    }
}
