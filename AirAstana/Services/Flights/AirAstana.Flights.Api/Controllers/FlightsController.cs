using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Extensions;
using AirAstana.Flights.Api.Mappers;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.Flights;
using AirAstana.Flights.Api.Models.Requests.Flights;
using AirAstana.Flights.Core.Commands.Flights.Create;
using AirAstana.Flights.Core.Commands.Flights.Delete;
using AirAstana.Flights.Core.Commands.Flights.Update;
using AirAstana.Flights.Core.Queries.Flights.GetAll;
using AirAstana.Flights.Core.Queries.Flights.GetById;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AirAstana.Flights.Api.Controllers
{
    /// <summary>
    ///     Контроллер рейсов.
    /// </summary>
    public class FlightsController : BaseController
    {
        /// <summary>
        ///     Получить список рейсов.
        /// </summary>
        /// <returns>Список рейсов.</returns>
        // GET api/flights
        [
            HttpGet,
            SwaggerResponse(200, type: typeof(WebResponse<IEnumerable<FlightModel>>)),
            SwaggerResponse(500, type: typeof(WebResponse))
        ]
        public async Task<IActionResult> Get()
        {
            return this.OkWebResponse((await Mediator.Send(new GetFlightsQuery())).Select(x => x.ToApiModel()).ToList());
        }

        /// <summary>
        ///     Получить рейс по идентификатору.
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns>Данные о рейсе.</returns>
        // GET api/flights/id
        [
            HttpGet,
            SwaggerResponse(200, type: typeof(WebResponse<FlightModel>)),
            SwaggerResponse(500, type: typeof(WebResponse))
        ]
        public async Task<IActionResult> Get([FromQuery] int flightId)
        {
            return this.OkWebResponse((await Mediator.Send(new GetFlightQuery(flightId))).ToApiModel());
        }

        /// <summary>
        ///     Добавить новый рейс.
        /// </summary>
        /// <param name="request">Запрос на создание рейса.</param>
        /// <returns>WebResponse с http статусом.</returns>
        // POST api/flights
        [
            HttpPost,
            SwaggerResponse(200, type: typeof(WebResponse)),
            SwaggerResponse(400, type: typeof(WebResponse)),
            SwaggerResponse(500, type: typeof(WebResponse))
        ]
        public async Task<IActionResult> Create([FromBody] CreateFlightRequest request)
        {
            var createdResponse = await Mediator.Send(new CreateFlightCommand(request.Flight.ToCoreModel()));
            return !createdResponse.Success ? this.BadRequestWebResponse(createdResponse.Message) : this.OkWebResponse();
        }

        /// <summary>
        ///     Изменить данные рейса.
        /// </summary>
        /// <param name="request">Запрос на изменения данных рейса.</param>
        /// <returns>WebResponse с http статусом.</returns>
        // PUT api/flights
        [
            HttpPut,
            SwaggerResponse(200, type: typeof(WebResponse)),
            SwaggerResponse(400, type: typeof(WebResponse)),
            SwaggerResponse(500, type: typeof(WebResponse))
        ]
        public async Task<IActionResult> Update([FromBody] UpdateFlightRequest request)
        {
            var updatedResponse = await Mediator.Send(new UpdateFlightCommand(request.Flight.ToCoreModel()));
            return !updatedResponse.Success ? this.BadRequestWebResponse(updatedResponse.Message) : this.OkWebResponse();
        }

        /// <summary>
        ///     Удалить рейс.
        /// </summary>
        /// <param name="flightId">ID рейса.</param>
        /// <returns>WebResponse с http статусом.</returns>
        // DELETE api/flights
        [
            HttpDelete,
            SwaggerResponse(200, type: typeof(WebResponse)),
            SwaggerResponse(400, type: typeof(WebResponse)),
            SwaggerResponse(500, type: typeof(WebResponse))
        ]
        public async Task<IActionResult> Update([FromQuery] int flightId)
        {
            var deletedResponse = await Mediator.Send(new DeleteFlightCommand(flightId));
            return !deletedResponse.Success ? this.BadRequestWebResponse(deletedResponse.Message) : this.OkWebResponse();
        }
    }
}
