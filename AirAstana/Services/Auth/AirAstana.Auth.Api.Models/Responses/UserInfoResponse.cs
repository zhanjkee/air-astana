using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AirAstana.Auth.Constants;
using Newtonsoft.Json;
using OpenIddict.Abstractions;

namespace AirAstana.Auth.Api.Models.Responses
{
    /// <summary>
    ///     The user info response model.
    /// </summary>
    public sealed class UserInfoResponse
    {
        /// <summary>
        ///     Gets the name of the user.
        /// </summary>
        [JsonProperty(OpenIddictConstants.Claims.Username)]
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this user is authenticated.
        /// </summary>
        [JsonProperty(AuthConstants.Claims.IsAuthenticated)]
        public bool IsAuthenticated { get; set; }

        /// <summary>
        ///     Gets or sets the exposed claims. (Just in case)
        /// </summary>
        [JsonProperty(AuthConstants.Claims.ExposedClaims)]
        public Dictionary<string, string> ExposedClaims { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserInfoResponse"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="isAuthenticated">if set to <c>true</c> [user authenticated].</param>
        /// <param name="claims">The claims</param>
        public UserInfoResponse(string userName, bool isAuthenticated, IEnumerable<Claim> claims)
        {
            UserName = userName;
            IsAuthenticated = isAuthenticated;
            ExposedClaims = claims.ToDictionary(c => c.Type, c => c.Value);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserInfoResponse"/> class.
        /// </summary>
        public UserInfoResponse()
        {
            
        }

        /// <summary>
        ///     Gets the claims.
        /// </summary>
        public IEnumerable<Claim> GetClaims()
        {
            return new Claim[]
            {
                new Claim(OpenIddictConstants.Claims.Username, UserName)
            }.Concat(ExposedClaims.Select(c => new Claim(c.Key, c.Value))).ToList();
        }
    }
}
