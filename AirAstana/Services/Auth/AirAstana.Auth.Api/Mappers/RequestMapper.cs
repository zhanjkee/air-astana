using AirAstana.Auth.Api.Models.Requests;
using AirAstana.Auth.Core.Commands.ExchangeRefreshToken;
using AirAstana.Auth.Core.Queries.Login;

namespace AirAstana.Auth.Api.Mappers
{
    /// <summary>
    ///     The request mapper.
    /// </summary>
    public static class RequestMapper
    {
        /// <summary>
        ///     Converts to core.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="remoteIpAddress">The remote ip address.</param>
        /// <returns></returns>
        public static LoginQuery ToCore(this LoginRequest request, string remoteIpAddress) =>
            request == null
            ? null
            : new LoginQuery(request.UserName, request.Password, remoteIpAddress, request.ClientId);

        /// <summary>
        ///     Converts to core.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="signingKey">The signing key.</param>
        /// <param name="remoteIpAddress">The remote ip address.</param>
        /// <returns></returns>
        public static ExchangeRefreshTokenCommand ToCore(this ExchangeRefreshTokenRequest request, string signingKey, string remoteIpAddress) =>
            request == null
            ? null
            : new ExchangeRefreshTokenCommand(request.AccessToken, request.RefreshToken, signingKey, remoteIpAddress, request.ClientId);
    }
}
