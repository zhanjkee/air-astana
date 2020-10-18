namespace AirAstana.Auth.Api.Models.Common
{
    /// <summary>
    ///     Токен доступа пользователя.
    /// </summary>
    public sealed class AccessToken
    {
        /// <summary>
        ///     Токен.
        /// </summary>
        public string Token { get; }
        /// <summary>
        ///     Время истечения токена в тиках.
        /// </summary>
        public int ExpiresIn { get; }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="token">Токен.</param>
        /// <param name="expiresIn">Время истечения токена в тиках.</param>
        public AccessToken(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
