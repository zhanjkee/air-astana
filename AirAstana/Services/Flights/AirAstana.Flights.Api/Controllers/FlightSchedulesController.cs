using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Extensions;
using AirAstana.Flights.Api.Mappers;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.FlightSchedules;
using AirAstana.Flights.Api.Models.Requests.FlightSchedules;
using AirAstana.Flights.Core.Commands.FlightSchedules.Create;
using AirAstana.Flights.Core.Commands.FlightSchedules.Delete;
using AirAstana.Flights.Core.Commands.FlightSchedules.Update;
using AirAstana.Flights.Core.Queries.FlightSchedules.GetAll;
using AirAstana.Flights.Core.Queries.FlightSchedules.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AirAstana.Flights.Api.Controllers
{
    /// <summary>
    ///     Контроллер расписании рейсов.
    /// </summary>
    [Authorize(Roles = "Administrator, Moderator", AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    [Route("api/flightSchedules")]
    [ApiController]
    public class FlightSchedulesController : BaseController
    {
        /// <summary>
        ///     Получить список расписании рейсов.
        /// </summary>
        /// <returns>Список расписании рейсов.</returns>
        // GET api/flightSchedules
        [AllowAnonymous]
        [HttpGet]
        [SwaggerResponse(200, type: typeof(WebResponse<IEnumerable<FlightScheduleModel>>))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> GetSchedules([FromQuery] GetFlightSchedulesRequest request)
        {
            return this.OkWebResponse((await Mediator.Send(new GetFlightSchedulesQuery(request.FromDate, request.ToDate, request.Asc)))
                .Select(x => x.ToApiModel())
                .ToList());
        }

        /// <summary>
        ///     Получить расписание рейса по идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Данные о расписании.</returns>
        // GET api/flightSchedules/id
        [AllowAnonymous]
        [HttpGet("id")]
        [SwaggerResponse(200, type: typeof(WebResponse<FlightScheduleModel>))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> GetScheduleById([FromQuery] int id)
        {
            return this.OkWebResponse((await Mediator.Send(new GetFlightScheduleQuery(id))).ToApiModel());
        }

        /// <summary>
        ///     Добавить новое расписание для рейса.
        /// </summary>
        /// <param name="request">Запрос на создание расписания.</param>
        /// <returns>WebResponse с http статусом.</returns>
        // POST api/flightSchedules
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [SwaggerResponse(200, type: typeof(WebResponse))]
        [SwaggerResponse(400, type: typeof(WebResponse))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> CreateFlightSchedule([FromBody] CreateFlightScheduleRequest request)
        {
            var createdResponse = await Mediator.Send(new CreateFlightScheduleCommand(request.FlightId, request.FlightSchedule.ToCoreModel()));
            return !createdResponse.Success ? this.BadRequestWebResponse(createdResponse.Message) : this.OkWebResponse();
        }

        /// <summary>
        ///     Изменить данные о расписании рейса.
        /// </summary>
        /// <param name="request">Запрос на изменение расписания.</param>
        /// <returns>WebResponse с http статусом.</returns>
        // PUT api/flightSchedules
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [SwaggerResponse(200, type: typeof(WebResponse))]
        [SwaggerResponse(400, type: typeof(WebResponse))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> UpdateFlightSchedule([FromBody] UpdateFlightScheduleRequest request)
        {
            var updatedResponse = await Mediator.Send(new UpdateFlightScheduleCommand(request.FlightSchedule.ToCoreModel()));
            return !updatedResponse.Success ? this.BadRequestWebResponse(updatedResponse.Message) : this.OkWebResponse();
        }

        /// <summary>
        ///     Удалить расписание рейса.
        /// </summary>
        /// <param name="id">ID расписания.</param>
        /// <returns>WebResponse с http статусом.</returns>
        // DELETE api/flightSchedules
        [Authorize(Roles = "Administrator")]
        [HttpDelete("id")]
        [SwaggerResponse(200, type: typeof(WebResponse))]
        [SwaggerResponse(400, type: typeof(WebResponse))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> DeleteFlightSchedule([FromQuery] int id)
        {
            var deletedResponse = await Mediator.Send(new DeleteFlightScheduleCommand(id));
            return !deletedResponse.Success ? this.BadRequestWebResponse(deletedResponse.Message) : this.OkWebResponse();
        }
    }
}
