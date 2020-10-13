namespace AirAstana.Auth.Identity
{
    /// <summary>
    ///     Дополнительные клеймы для <see cref="UserIdentity"/>
    /// </summary>
    public static class UserIdentityClaimsTypes
    {
        /// <summary>
        ///     Флаг, авторизован ли пользователь.
        /// </summary>
        public const string IsAuthorized = "is_authorized";
    }
}
