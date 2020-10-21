using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Flights.Api.ActionResults
{
    /// <summary>
    ///     A <see cref="ObjectResult"/> that when executed will produce a 204 No Content response.
    /// </summary>
    public class NoContentObjectResult : ObjectResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NoContentObjectResult"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public NoContentObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status204NoContent;
        }
    }
}
