using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Flights.Api.ActionResults
{
    /// <summary>
    ///     The internal server error object result class.
    /// </summary>
    public class InternalServerErrorObjectResult : ObjectResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InternalServerErrorObjectResult"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
