using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace AirAstana.Auth.Api.Models.Requests
{
    /// <summary>
    ///     The refresh grant request model.
    /// </summary>
    public sealed class RefreshGrantRequest
    {
        /// <summary>
        ///     Gets or sets the type of the grant.
        /// </summary>
        [Required]
        [JsonProperty(Parameters.GrantType)]
        public string GrantType { get; set; } = GrantTypes.RefreshToken;

        /// <summary>
        ///     Gets or sets the refresh token.
        /// </summary>
        [Required]
        [JsonProperty(GrantTypes.RefreshToken)]
        public string RefreshToken { get; set; }

        /// <summary>
        ///     Gets or sets the scope.
        /// </summary>
        [Required]
        [JsonProperty(Parameters.Scope)]
        public string Scope { get; set; } = "openid offline_access";
    }
}
