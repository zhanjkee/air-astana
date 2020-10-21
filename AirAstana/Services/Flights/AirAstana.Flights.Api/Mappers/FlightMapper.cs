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
                Destination = flight.Destination.ToCoreModel(),
                FlightNumber = flight.FlightNumber,
                Source = flight.Source.ToCoreModel()
            };
        }

        public static FlightModel ToApiModel(this Flight flight)
        {
            if (flight == null) return null;

            return new FlightModel
            {
                Destination = flight.Destination.ToApiModel(),
                FlightNumber = flight.FlightNumber,
                Source = flight.Source.ToApiModel(),
                Schedules = flight.Schedules?.Select(x => x?.ToApiModel()).ToList()
            };
        }
    }
}
