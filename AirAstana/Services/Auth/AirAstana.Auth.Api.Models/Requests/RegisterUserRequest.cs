using System.ComponentModel.DataAnnotations;

namespace AirAstana.Auth.Api.Models.Requests
{
    /// <summary>
    ///     The register user request model.
    /// </summary>
    public sealed class RegisterUserRequest
    {
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        ///     Gets or sets the name of the user.
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
