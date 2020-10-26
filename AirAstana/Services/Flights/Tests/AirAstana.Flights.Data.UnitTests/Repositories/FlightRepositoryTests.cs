using System;
using System.Threading.Tasks;
using AirAstana.Flights.Data.InMemory;
using AirAstana.Flights.Data.UoW;
using Xunit;

namespace AirAstana.Flights.Data.UnitTests.Repositories
{
    public class FlightRepositoryTests
    {
        [Fact]
        public async Task AddDelayTimeTests()
        {
            var factory = new InMemoryDbContextFactory();
            using (var unitOfWork = new UnitOfWork(factory))
            {
                var repository = unitOfWork.FlightScheduleRepository;
                var firstFlightSchedule = await repository.GetByIdAsync(1);
                var delayTimeSpan = new TimeSpan(0, 3, 0, 0);

                firstFlightSchedule.AddDelayTime(delayTimeSpan);

                repository.Update(firstFlightSchedule);
                await unitOfWork.SaveChangesAsync();

                firstFlightSchedule = await repository.GetByIdAsync(1);

                Assert.True(firstFlightSchedule.Delay.HasValue);
                Assert.True(delayTimeSpan.Ticks == firstFlightSchedule.Delay.Value.Ticks);
            }
        }

        [Fact]
        public async Task UpdateScheduleTests()
        {
            var factory = new InMemoryDbContextFactory();
            using (var unitOfWork = new UnitOfWork(factory))
            {
                var repository = unitOfWork.FlightScheduleRepository;
                var firstFlightSchedule = await repository.GetByIdAsync(1);
                var oldDuration = firstFlightSchedule.Duration;

                firstFlightSchedule.Duration = new TimeSpan(0, 5, 55, 55);
                repository.Update(firstFlightSchedule);
                await unitOfWork.SaveChangesAsync();

                firstFlightSchedule = await repository.GetByIdAsync(1);

                Assert.True(oldDuration.Ticks != firstFlightSchedule.Duration.Ticks);
            }
        }
    }
}
