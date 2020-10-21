using AirAstana.Flights.Api.ActionResults;
using AirAstana.Flights.Api.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Flights.Api.Extensions
{
    /// <summary>
    ///     Расширение для ControllerBase.
    /// </summary>
    public static class ApiControllerActionResultExtention
    {
        /// <summary>
        ///     Возвращает WebResponse с кодом 200 и контентом
        /// </summary>
        public static IActionResult OkWebResponse<T>(this ControllerBase controller, T content)
        {
            return new OkObjectResult(new WebResponse
            {
                Body = content
            });
        }

        /// <summary>
        ///     Возвращает WebResponse с кодом 200 без контента
        /// </summary>
        public static IActionResult OkWebResponse(this ControllerBase controller)
        {
            return new OkObjectResult(new WebResponse());
        }

        /// <summary>
        ///     Возвращает WebResponse с кодом 201 и контентом
        /// </summary>
        /// <remarks>Использовать в случае, когда сощдается ресурс</remarks>
        public static IActionResult CreatedWebResponse<T>(this ControllerBase controller, T content)
        {
            return new CreatedObjectResult(new WebResponse
            {
                Body = content
            });
        }

        /// <summary>
        ///     Возвращает WebResponse с кодом 204 и описанием проблемы
        /// </summary>
        public static IActionResult NoContentWebResponse(this ControllerBase controller, string warningMessage = "")
        {
            return new NoContentObjectResult(new WebResponse(new[]
                {
                    new ErrorMessage
                    {
                        Message = warningMessage
                    }
                }
            ));
        }

        /// <summary>
        ///     Возвращает WebResponse с кодом 400 и описанием проблемы
        /// </summary>
        public static IActionResult BadRequestWebResponse(this ControllerBase controller,
            string warningMessage = "Bad request")
        {
            return new BadRequestObjectResult(new WebResponse(new[]
                {
                    new ErrorMessage
                    {
                        Message = warningMessage
                    }
                }
            ));
        }

        /// <summary>
        ///     Возвращает WebResponse с кодом 403 и описанием проблемы
        /// </summary>
        public static IActionResult ForbiddenWebResponse(this ControllerBase controller,
            string warningMessage = "You have no access to resource")
        {
            return new ForbidObjectResult(new WebResponse(new[]
                {
                    new ErrorMessage
                    {
                        Message = warningMessage
                    }
                }
            ));
        }

        /// <summary>
        ///     Возвращает WebResponse с кодом 404 и описанием проблемы
        /// </summary>
        public static IActionResult NotFoundWebResponse(this ControllerBase controller,
            string warningMessage = "Content not found")
        {
            return new NotFoundObjectResult(new WebResponse(new[]
                {
                    new ErrorMessage
                    {
                        Message = warningMessage
                    }
                }
            ));
        }

        /// <summary>
        ///     Возвращает WebResponse с кодом 500 и описанием проблемы
        /// </summary>
        public static IActionResult InternalServerErrorWebResponse(this ControllerBase controller,
            string warningMessage = "Internal server error")
        {
            return new InternalServerErrorObjectResult(new WebResponse(new[]
                {
                    new ErrorMessage
                    {
                        Message = warningMessage
                    }
                }
            ));
        }
    }
}