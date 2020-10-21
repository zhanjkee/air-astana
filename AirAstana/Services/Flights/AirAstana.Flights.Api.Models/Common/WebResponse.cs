using System;
using System.Collections.Generic;

namespace AirAstana.Flights.Api.Models.Common
{
    /// <summary>
    ///     The web response class.
    /// </summary>
    public class WebResponse : WebResponse<object>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WebResponse"/> class.
        /// </summary>
        public WebResponse()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebResponse"/> class.
        /// </summary>
        /// <param name="body">The body.</param>
        public WebResponse(object body)
        {
            Body = body;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebResponse"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public WebResponse(Exception exception)
        {
            Errors = new[]
            {
                new ErrorMessage
                {
                    Message = exception.GetBaseException().Message
                }
            };
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebResponse"/> class.
        /// </summary>
        /// <param name="errorMessages">The error messages.</param>
        public WebResponse(ICollection<ErrorMessage> errorMessages)
        {
            Errors = errorMessages;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebResponse"/> class.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="errorMessages">The error messages.</param>
        public WebResponse(object body, ICollection<ErrorMessage> errorMessages)
        {
            Body = body;
            Errors = errorMessages;
        }
    }

    /// <summary>
    ///     The web response class.
    /// </summary>
    /// <typeparam name="TBody">The type of the body.</typeparam>
    public class WebResponse<TBody>
    {
        /// <summary>
        ///     Gets or sets the errors.
        /// </summary>
        public ICollection<ErrorMessage> Errors { get; set; }

        /// <summary>
        ///     Gets or sets the body.
        /// </summary>
        public TBody Body { get; set; }

    }

    /// <summary>
    /// The error message class.
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the parameters.
        /// </summary>
        public object Params { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
    }
}
