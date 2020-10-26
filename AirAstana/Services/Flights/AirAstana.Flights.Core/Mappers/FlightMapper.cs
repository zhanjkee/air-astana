using System.Linq;
using AirAstana.Flights.Core.Models.Flights;
using AirAstana.Flights.Domain.Entities;

namespace AirAstana.Flights.Core.Mappers
{
    public static class FlightMapper
    {
        public static FlightEntity ToEntity(this Flight flight)
        {
            if (flight == null) return null;

            return new FlightEntity
            {
                Id = flight.Id,
                DestinationId = flight.DestinationId,
                Destination = flight.Destination.ToEntity(),
                FlightNumber = flight.FlightNumber,
                SourceId = flight.SourceId,
                Source = flight.Source.ToEntity()
            };
        }

        public static Flight ToModel(this FlightEntity flight, bool mapSchedule = true)
        {
            if (flight == null) return null;

            var result = new Flight
            {
                Id = flight.Id,
                DestinationId = flight.DestinationId,
                Destination = flight.Destination.ToModel(),
                FlightNumber = flight.FlightNumber,
                SourceId = flight.SourceId,
                Source = flight.Source.ToModel(),
            };

            if (mapSchedule) result.Schedules = flight.Schedules?.Select(x => x?.ToModel(false)).ToList();

            return result;
        }
    }
}
