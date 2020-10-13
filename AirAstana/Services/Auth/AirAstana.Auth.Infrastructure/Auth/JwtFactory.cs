using AirAstana.Auth.Core.Interfaces.Services;
using AirAstana.Auth.Core.Models;
using AirAstana.Auth.Identity;
using AirAstana.Auth.Infrastructure.Auth.Interfaces;
using AirAstana.Auth.Options;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace AirAstana.Auth.Infrastructure.Auth
{
    /// <summary>
    ///     Фабрика для создания закодированного токена.
    /// </summary>
    public sealed class JwtFactory : IJwtFactory
    {
        private readonly IJwtTokenHandler _jwtTokenHandler;
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtFactory(IJwtTokenHandler jwtTokenHandler, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }

        public AccessToken GenerateEncodedToken(UserInfo userInfo, string clientId)
        {
            return GenerateEncodedTokenAsync(userInfo, clientId).GetAwaiter().GetResult();
        }

        public async Task<AccessToken> GenerateEncodedTokenAsync(UserInfo userInfo, string clientId)
        {
            var jwtId = await _jwtOptions.JtiGenerator();
            var issuedAt = ToUnixEpochDate(_jwtOptions.IssuedAt).ToString();
            var identity = GenerateUserIdentity(userInfo, clientId, jwtId, issuedAt);

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                identity.Claims,
                _jwtOptions.NotBefore,
                _jwtOptions.Expiration,
                _jwtOptions.SigningCredentials);

            return new AccessToken(_jwtTokenHandler.WriteToken(jwt), (int)_jwtOptions.ValidFor.TotalSeconds);
        }
       
        private static UserIdentity GenerateUserIdentity(UserInfo userInfo, string clientId, string jwtId, string issuedAt)
        {
            return new UserIdentity(userInfo.Id, userInfo.ToString(), userInfo.UserName, userInfo.ZoneInfo, userInfo.Locale, clientId, jwtId, issuedAt, userInfo.Roles);
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }        
    }
}
