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

        public static FlightSchedule ToModel(this FlightScheduleEntity flightSchedule)
        {
            if (flightSchedule == null) return null;
            return new FlightSchedule
            {
                Id = flightSchedule.Id,
                Delay = flightSchedule.Delay,
                ActualDeparture = flightSchedule.ActualDeparture,
                Departure = flightSchedule.Departure,
                Duration = flightSchedule.Duration,
                FlightId = flightSchedule.FlightId
            };
        }
    }
}
