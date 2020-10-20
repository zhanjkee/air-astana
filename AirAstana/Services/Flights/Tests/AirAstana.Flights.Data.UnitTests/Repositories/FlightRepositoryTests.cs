using System;
using System.Threading.Tasks;
using AirAstana.Flights.Data.InMemory;
using AirAstana.Flights.Data.Repositories;
using Xunit;

namespace AirAstana.Flights.Data.UnitTests.Repositories
{
    public class FlightRepositoryTests
    {
        [Fact]
        public async Task AddDelayTimeTests()
        {
            var factory = new InMemoryDbContextFactory();
            using (var repository = new FlightRepository(factory.Create()))
            {
                var firstFlightSchedule = await repository.GetFlightScheduleByIdAsync(1);
                var delayTimeSpan = new TimeSpan(0, 3, 0, 0);

                await repository.AddDelayTimeAsync(firstFlightSchedule, delayTimeSpan);
                await repository.SaveChangesAsync();

                firstFlightSchedule = await repository.GetFlightScheduleByIdAsync(1);

                Assert.True(firstFlightSchedule.Delay.HasValue);
                Assert.True(delayTimeSpan.Ticks == firstFlightSchedule.Delay.Value.Ticks);
            }
        }

        [Fact]
        public async Task UpdateScheduleTests()
        {
            var factory = new InMemoryDbContextFactory();
            using (var repository = new FlightRepository(factory.Create()))
            {
                var firstFlightSchedule = await repository.GetFlightScheduleByIdAsync(1);
                var oldDuration = firstFlightSchedule.Duration;

                firstFlightSchedule.Duration = new TimeSpan(0, 5, 55, 55);
                await repository.UpdateScheduleAsync(firstFlightSchedule);
                await repository.SaveChangesAsync();

                firstFlightSchedule = await repository.GetFlightScheduleByIdAsync(1);

                Assert.True(oldDuration.Ticks != firstFlightSchedule.Duration.Ticks);
            }
        }
    }
}
