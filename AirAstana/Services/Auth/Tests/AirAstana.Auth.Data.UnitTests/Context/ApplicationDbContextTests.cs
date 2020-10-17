using AirAstana.Auth.Data.Context;
using AirAstana.Auth.Data.InMemory;
using AirAstana.Auth.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AirAstana.Auth.Data.UnitTests
{
    public class ApplicationDbContextTests
    {
        private readonly ApplicationDbContext _sut;

        public ApplicationDbContextTests()
        {
            _sut = new InMemoryDbContextFactory().Create();
        }

        [Fact]
        public async Task CreateRefreshTokenTests()
        {
            // Arrange.
            var refreshTokens = new RefreshTokenEntity[]
            {
                new RefreshTokenEntity(Guid.NewGuid().ToString(), DateTime.Now.AddDays(2), Guid.NewGuid().ToString(), "localhost"),
                new RefreshTokenEntity(Guid.NewGuid().ToString(), DateTime.Now.AddDays(2), Guid.NewGuid().ToString(), "localhost"),
                new RefreshTokenEntity(Guid.NewGuid().ToString(), DateTime.Now.AddDays(2), Guid.NewGuid().ToString(), "localhost")
            };

            // Act.
            _sut.RefreshTokens.AddRange(refreshTokens);
            await _sut.SaveChangesAsync();

            // Assert.
            Assert.Equal(refreshTokens.Count(), _sut.RefreshTokens.Count());
        }
    }
}
