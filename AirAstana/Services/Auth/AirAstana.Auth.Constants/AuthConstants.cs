namespace AirAstana.Auth.Constants
{
    public static class AuthConstants
    {
        public static class Roles
        {
            public const string Administrator = nameof(Administrator),
                                Moderator = nameof(Moderator);
        }

        public static class Claims
        {
            public const string IsAuthenticated = "is_authenticated";
            public const string ExposedClaims = "exposed_claims";
        }
    }
}
