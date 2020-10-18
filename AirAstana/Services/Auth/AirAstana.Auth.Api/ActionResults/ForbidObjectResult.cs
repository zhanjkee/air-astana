using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Auth.Api.ActionResults
{
    /// <summary>
    ///     An <see cref="ObjectResult"/> that on execution invokes <see cref="M:HttpContext.ForbidAsync"/>.
    /// </summary>
    public class ForbidObjectResult : ObjectResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ForbidObjectResult"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ForbidObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
    }
}
