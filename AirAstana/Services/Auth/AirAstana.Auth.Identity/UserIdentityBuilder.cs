using System;
using System.IdentityModel.Tokens.Jwt;

namespace AirAstana.Auth.Identity
{
    /// <summary>
    ///     Интерфейс для добавления токена доступа.
    /// </summary>
    public interface IUserIdentityAccessToken
    {
        /// <summary>
        ///     Установить токен доступа.
        /// </summary>
        /// <param name="accessToken">Токен доступа.</param>
        /// <returns>IUserIdentityBuilder</returns>
        IUserIdentityBuilder SetAccessToken(string accessToken);
    }

    /// <summary>
    ///     Построитель для UserIdentity.
    /// </summary>
    public interface IUserIdentityBuilder
    {
        /// <summary>
        ///     Построить удостоверение пользователя.
        /// </summary>
        /// <returns>Удостоверение пользователя.</returns>
        UserIdentity Build();
    }

    /// <summary>
    ///     Построитель для UserIdentity.
    /// </summary>
    public sealed class UserIdentityBuilder : IUserIdentityAccessToken, IUserIdentityBuilder
    {
        private string _accessToken;

        /// <summary>
        ///     Построить удостоверение пользователя.
        /// </summary>
        /// <returns>Удостоверение пользователя.</returns>
        public UserIdentity Build()
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(_accessToken) as JwtSecurityToken;
            return new UserIdentity(token?.Claims);
        }

        /// <summary>
        ///     Установить токен доступа.
        /// </summary>
        /// <param name="accessToken">Токен доступа.</param>
        /// <returns>IUserIdentityBuilder</returns>
        public IUserIdentityBuilder SetAccessToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            _accessToken = accessToken;
            return this;
        }
    }
}
