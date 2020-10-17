using AirAstana.Auth.Core.Models;
using System.Collections.Generic;

namespace AirAstana.Auth.Core.Queries.Login
{
    public class LoginResponse : ResponseMessage
    { 
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }
        public IEnumerable<Error> Errors { get; }

        public LoginResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public LoginResponse(AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
