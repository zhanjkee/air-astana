using AirAstana.Auth.Core.Models;
using AirAstana.Auth.Infrastructure.Auth;
using AirAstana.Auth.Infrastructure.Auth.Interfaces;
using AirAstana.Auth.Options;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirAstana.Auth.Infrastructure.UnitTests
{
    public class JwtFactoryUnitTests
    {
        [Fact]
        public async Task GenerateEncodedToken_GivenValidInputs_ReturnsExpectedTokenData()
        {
            // Arrange.
            var token = Guid.NewGuid().ToString();
            var id = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var userInfo = new UserInfo() 
            { 
                Id = 1, FirstName = "Admin", LastName = "Admin", Locale = "RU-ru", Roles = new string[] { "Administrator" }, UserName = "admin", ZoneInfo = "Default/UTC" 
            };
            var jwtIssuerOptions = new JwtIssuerOptions
            {
                Issuer = "",
                Audience = "",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secret_key")), SecurityAlgorithms.HmacSha256)
            };

            var mockJwtTokenHandler = new Mock<IJwtTokenHandler>();
            mockJwtTokenHandler.Setup(handler => handler.WriteToken(It.IsAny<JwtSecurityToken>())).Returns(token);

            var jwtFactory = new JwtFactory(mockJwtTokenHandler.Object, Microsoft.Extensions.Options.Options.Create(jwtIssuerOptions));

            // Act.
            var result = await jwtFactory.GenerateEncodedTokenAsync(userInfo, clientId);

            // Assert.
            Assert.Equal(token, result.Token);
        }
    }
}
