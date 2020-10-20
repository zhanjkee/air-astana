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
                Destination = flight.Destination.ToEntity(),
                FlightNumber = flight.FlightNumber,
                Source = flight.Source.ToEntity()
            };
        }

        public static Flight ToModel(this FlightEntity flight)
        {
            if (flight == null) return null;

            return new Flight
            {
                Destination = flight.Destination.ToModel(),
                FlightNumber = flight.FlightNumber,
                Source = flight.Source.ToModel(),
                Schedules = flight.Schedules?.Select(x => x?.ToModel()).ToList()
            };
        }
    }
}
