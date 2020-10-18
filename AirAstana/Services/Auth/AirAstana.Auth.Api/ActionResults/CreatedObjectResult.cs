using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Auth.Api.ActionResults
{
    /// <summary>
    ///     An <see cref="ObjectResult"/> that returns a Created (201) response.
    /// </summary>
    /// <seealso cref="ObjectResult" />
    public class CreatedObjectResult : ObjectResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreatedObjectResult"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public CreatedObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status201Created;
        }
    }
}
