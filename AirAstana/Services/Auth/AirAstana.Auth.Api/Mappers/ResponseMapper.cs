using AirAstana.Auth.Api.Models.Common;
using AirAstana.Auth.Api.Models.Responses;

namespace AirAstana.Auth.Api.Mappers
{
    /// <summary>
    ///     The response mapper.
    /// </summary>
    public static class ResponseMapper
    {
        /// <summary>
        ///     Converts to api.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static LoginResponse ToApi(this Core.Queries.Login.LoginResponse response) =>
            response == null
            ? null
            : new LoginResponse(response.AccessToken.ToApi(), response.RefreshToken);

        /// <summary>
        ///     Converts to api.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns></returns>
        public static AccessToken ToApi(this Core.Models.AccessToken accessToken) => 
            accessToken == null 
            ? null 
            : new AccessToken(accessToken.Token, accessToken.ExpiresIn);

        /// <summary>
        ///     Converts to api.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static ExchangeRefreshTokenResponse ToApi(this Core.Commands.ExchangeRefreshToken.ExchangeRefreshTokenResponse response) =>
            response == null
            ? null
            : new ExchangeRefreshTokenResponse(response.AccessToken.ToApi(), response.RefreshToken);

        /// <summary>
        ///     Converts to api.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static RegisterUserResponse ToApi(this Core.Commands.RegisterUser.RegisterUserResponse response) =>
            response == null
            ? null
            : new RegisterUserResponse(response.Id);
    }
}
