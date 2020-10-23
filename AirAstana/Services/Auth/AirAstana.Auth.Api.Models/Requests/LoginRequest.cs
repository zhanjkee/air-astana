using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace AirAstana.Auth.Api.Models.Requests
{
    /// <summary>
    ///     The login request model.
    /// </summary>
    public sealed class LoginRequest
    {
        /// <summary>
        ///     Gets or sets the type of the grant.
        /// </summary>
        [Required]
        [JsonProperty(Parameters.GrantType)]
        public string GrantType { get; set; } = GrantTypes.Password;

        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        [Required]
        [JsonProperty(Parameters.Username)]
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        [Required]
        [JsonProperty(Parameters.Password)]
        public string Password { get; set; }

        /// <summary>
        ///     Gets or sets the scope.
        /// </summary>
        [Required]
        [JsonProperty(Parameters.Scope)]
        public string Scope { get; set; } = "openid offline_access";
    }
}
