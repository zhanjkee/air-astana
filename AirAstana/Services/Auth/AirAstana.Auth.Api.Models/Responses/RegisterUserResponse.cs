namespace AirAstana.Auth.Api.Models.Responses
{
    /// <summary>
    ///     The register user response model.
    /// </summary>
    public sealed class RegisterUserResponse
    {
        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterUserResponse"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public RegisterUserResponse(string id)
        {
            Id = id;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterUserResponse"/> class.
        /// </summary>
        public RegisterUserResponse()
        {
            
        }
    }
}
