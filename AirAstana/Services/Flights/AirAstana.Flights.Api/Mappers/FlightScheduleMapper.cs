using System;
using AirAstana.Flights.Api.Models.FlightSchedules;
using AirAstana.Flights.Api.Models.Locations;
using AirAstana.Flights.Core.Models.FlightSchedules;

namespace AirAstana.Flights.Api.Mappers
{
    public static class FlightScheduleMapper
    {
        public static FlightScheduleModel ToApiModel(this FlightSchedule flightSchedule, bool mapFlight = true)
        {
            if (flightSchedule == null) return null;
            var result = new FlightScheduleModel
            {
                Id = flightSchedule.Id,
                Delay = flightSchedule.Delay,
                ActualDeparture = flightSchedule.ActualDeparture,
                Departure = flightSchedule.Departure,
                Duration = flightSchedule.Duration,
                FlightId = flightSchedule.FlightId
            };

            if (mapFlight)
            {
                result.Flight = flightSchedule.Flight.ToApiModel(false);
                result.Arrival = GetArrivalDate(flightSchedule.Departure, flightSchedule.Duration, result.Flight.Source,
                    result.Flight.Destination);
            }

            return result;
        }

        public static FlightSchedule ToCoreModel(this FlightScheduleModel flightSchedule)
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

        private static DateTime GetArrivalDate(DateTime date, TimeSpan duration, LocationModel sourceLocation, LocationModel targetLocation)
        {
            // NOTE: Конвертацию времени в рамках тестового задания не делаю. Требует доп. времени.
            return date.Add(duration);
        }
    }
}
