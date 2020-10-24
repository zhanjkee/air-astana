using AirAstana.Flights.Core.Models.FlightSchedules;
using AirAstana.Flights.Domain.Entities;

namespace AirAstana.Flights.Core.Mappers
{
    public static class FlightScheduleMapper
    {
        public static FlightScheduleEntity ToEntity(this FlightSchedule flightSchedule)
        {
            if (flightSchedule == null) return null;
            return new FlightScheduleEntity
            {
                Id = flightSchedule.Id,
                Delay = flightSchedule.Delay,
                ActualDeparture = flightSchedule.ActualDeparture,
                Departure = flightSchedule.Departure,
                Duration = flightSchedule.Duration,
                FlightId = flightSchedule.FlightId
            };
        }

        public static FlightSchedule ToModel(this FlightScheduleEntity flightSchedule, bool mapFlight = true)
        {
            if (flightSchedule == null) return null;
            var result = new FlightSchedule
            {
                Id = flightSchedule.Id,
                Delay = flightSchedule.Delay,
                ActualDeparture = flightSchedule.ActualDeparture,
                Departure = flightSchedule.Departure,
                Duration = flightSchedule.Duration,
                FlightId = flightSchedule.FlightId,
            };

            if (mapFlight) result.Flight = flightSchedule.Flight.ToModel(false);

            return result;
        }
    }
}
