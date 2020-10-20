using System;
using System.Collections.Generic;
using System.Linq;
using AirAstana.Flights.Data.Context;
using AirAstana.Flights.Domain.Entities;

namespace AirAstana.Flights.Data.Extensions
{
    public static class SeedDataExtension
    {
        public static void SeedData(FlightsContext context)
        {
            if (context.FlightSchedules.Any()) return;

            var astana = GenerateLocation("Astana", "Kazakhstan", "KZ", null, "Central Asia Standard Time");
            var almaty = GenerateLocation("Almaty", "Kazakhstan", "KZ", null, "Central Asia Standard Time");
            var shymkent = GenerateLocation("Shymkent", "Kazakhstan", "KZ", null, "Central Asia Standard Time");
            var saintPetersburg = GenerateLocation("Saint-Petersburg", "Russia", "Ru", "Leningrad", "Russian Standard Time");

            var flightInfo = new Dictionary<Tuple<LocationEntity, LocationEntity>, DayOfWeek[]>();

            CreateFlightInfos(flightInfo, astana, almaty, shymkent, saintPetersburg);

            var index = 0;
            foreach (var flightInfoItem in flightInfo)
            {
                var flight = GenerateFlight(flightInfoItem.Key.Item1, flightInfoItem.Key.Item2, flightInfoItem.Value, ++index);
                context.Flights.Add(flight);
            }

            context.SaveChanges();
        }

        private static LocationEntity GenerateLocation(string city, string country, string countryCode, string state, string timeZone)
        {
            return new LocationEntity
            {
                City = city,
                Country = country,
                CountryCode = countryCode,
                State = state,
                LocationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone)
            };
        }

        private static void CreateFlightInfos(Dictionary<Tuple<LocationEntity, LocationEntity>, DayOfWeek[]> flightInfo,
                LocationEntity astana,
                LocationEntity almaty,
                LocationEntity shymkent,
                LocationEntity saintPetersburg
            )
        {
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(astana, almaty),
                          new[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(astana, saintPetersburg),
                           new[] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Thursday });
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(astana, shymkent),
                           new[]
                               {
                                   DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday,
                                   DayOfWeek.Friday, DayOfWeek.Saturday,
                               });

            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(almaty, astana),
                           new[] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Friday });
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(almaty, saintPetersburg),
                           new[] { DayOfWeek.Wednesday, DayOfWeek.Sunday, DayOfWeek.Friday });
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(almaty, shymkent),
                           new[] { DayOfWeek.Monday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Sunday, });

            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(saintPetersburg, astana),
                           new[] { DayOfWeek.Sunday, DayOfWeek.Saturday, DayOfWeek.Friday });
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(saintPetersburg, almaty),
                           new[] { DayOfWeek.Monday, DayOfWeek.Friday });
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(saintPetersburg, shymkent),
                           new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, });

            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(shymkent, astana),
                           new[]
                               {
                                   DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday,
                                   DayOfWeek.Friday, DayOfWeek.Saturday
                               });
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(shymkent, almaty),
                           new[] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
            flightInfo.Add(new Tuple<LocationEntity, LocationEntity>(shymkent, saintPetersburg),
                           new[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday });
        }

        private static FlightEntity GenerateFlight(LocationEntity source, LocationEntity destination, DayOfWeek[] weeklyDays, int flightNumber)
        {
            var start = FindPreviousSunday();
            var flightSchedules = new List<FlightScheduleEntity>();
            for (var i = 0; i < 26; i++)
            {
                foreach (var weeklyDay in weeklyDays)
                {
                    var today = start.AddDays(7 * i + (int)weeklyDay).AddHours(8);
                    var flightSchedule = new FlightScheduleEntity
                    {
                        Departure = today,
                        Duration = new TimeSpan(2, 30, 0)
                    };
                    flightSchedules.Add(flightSchedule);
                }
            }

            var flight = new FlightEntity
            {
                Source = source,
                Destination = destination,
                FlightNumber = $"BY{flightNumber:3}",
                Schedules = flightSchedules,
            };
            return flight;
        }

        private static DateTime FindPreviousSunday()
        {
            var today = DateTime.Today;
            var dayNumber = (int)today.DayOfWeek;
            var target = today.AddDays(dayNumber == 0 ? -7 : -dayNumber);
            return target;
        }
    }
}
