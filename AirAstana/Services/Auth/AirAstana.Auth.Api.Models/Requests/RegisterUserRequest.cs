namespace AirAstana.Auth.Api.Models.Requests
{
    /// <summary>
    ///     The register user request model.
    /// </summary>
    public class RegisterUserRequest
    {
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
