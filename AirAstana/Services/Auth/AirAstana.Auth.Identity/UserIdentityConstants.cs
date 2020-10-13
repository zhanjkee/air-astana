namespace AirAstana.Auth.Identity
{
    /// <summary>
    ///     Дополнительные клеймы для <see cref="UserIdentity"/>
    /// </summary>
    public static class UserIdentityConstants
    {
        /// <summary>
        ///     ID пользователя.
        /// </summary>
        public const string Id = "id";

        /// <summary>
        ///     Имя пользователя.
        /// </summary>
        public const string Name = "name";

        /// <summary>
        ///     Часовой пояс пользователя.
        /// </summary>
        public const string ZoneInfo = "zone_info";


        /// <summary>
        ///     Локаль пользователя.
        /// </summary>
        public const string Locale = "locale";

        /// <summary>
        ///     ID клиента.
        /// </summary>
        public const string ClientId = "client_id";

        /// <summary>
        ///     Роли пользователя.
        /// </summary>
        public const string Role = "role";

        /// <summary>
        ///     Виды аутентификации.
        /// </summary>
        public static class AuthenticationTypes
        {
            /// <summary>
            ///     JWT.
            /// </summary>
            public const string Jwt = "JWT";
        }
    }
}
