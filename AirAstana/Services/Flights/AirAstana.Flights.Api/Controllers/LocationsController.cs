using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirAstana.Flights.Api.Extensions;
using AirAstana.Flights.Api.Mappers;
using AirAstana.Flights.Api.Models.Common;
using AirAstana.Flights.Api.Models.Locations;
using AirAstana.Flights.Api.Models.Requests.Locations;
using AirAstana.Flights.Core.Commands.Locations.Create;
using AirAstana.Flights.Core.Commands.Locations.Delete;
using AirAstana.Flights.Core.Commands.Locations.Update;
using AirAstana.Flights.Core.Queries.Locations.GetAll;
using AirAstana.Flights.Core.Queries.Locations.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;
using Swashbuckle.AspNetCore.Annotations;

namespace AirAstana.Flights.Api.Controllers
{
    /// <summary>
    ///     Контроллер локации.
    /// </summary>
    [Authorize(Roles = "Administrator", AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : BaseController
    {
        /// <summary>
        ///     Получить список локации.
        /// </summary>
        /// <returns>Список локации.</returns>
        // GET api/locations
        [AllowAnonymous]
        [HttpGet]
        [SwaggerResponse(200, type: typeof(WebResponse<IEnumerable<LocationModel>>))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> GetLocations()
        {
            return this.OkWebResponse((await Mediator.Send(new GetLocationsQuery())).Select(x => x.ToApiModel()).ToList());
        }

        /// <summary>
        ///     Получить локацию по идентификатору.
        /// </summary>
        /// <returns>Локация.</returns>
        // GET api/locations/id
        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerResponse(200, type: typeof(WebResponse<LocationModel>))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> GetLocation(int id)
        {
            return this.OkWebResponse((await Mediator.Send(new GetLocationQuery(id))).ToApiModel());
        }

        /// <summary>
        ///     Добавить новую локацию.
        /// </summary>
        /// <param name="request">Запрос на добавление локации.</param>
        /// <returns>WebResponse с http статусом.</returns>
        // POST api/locations
        [HttpPost]
        [SwaggerResponse(200, type: typeof(WebResponse))]
        [SwaggerResponse(400, type: typeof(WebResponse))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequest request)
        {
            var createdResponse = await Mediator.Send(new CreateLocationCommand(request.Location.ToCoreModel()));
            return !createdResponse.Success ? this.BadRequestWebResponse(createdResponse.Message) : this.OkWebResponse();
        }

        /// <summary>
        ///     Изменить локацию.
        /// </summary>
        /// <param name="request">Запрос на добавление локации.</param>
        /// <returns>WebResponse с http статусом.</returns>
        // POST api/locations
        [HttpPut]
        [SwaggerResponse(200, type: typeof(WebResponse))]
        [SwaggerResponse(400, type: typeof(WebResponse))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationRequest request)
        {
            var createdResponse = await Mediator.Send(new UpdateLocationCommand(request.Location.ToCoreModel()));
            return !createdResponse.Success ? this.BadRequestWebResponse(createdResponse.Message) : this.OkWebResponse();
        }

        /// <summary>
        ///     Удалить локацию.
        /// </summary>
        /// <returns>Локация.</returns>
        // GET api/locations/id
        [HttpDelete("{id}")]
        [SwaggerResponse(200, type: typeof(WebResponse))]
        [SwaggerResponse(400, type: typeof(WebResponse))]
        [SwaggerResponse(500, type: typeof(WebResponse))]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var deletedResponse = await Mediator.Send(new DeleteLocationCommand(id));
            return !deletedResponse.Success ? this.BadRequestWebResponse(deletedResponse.Message) : this.OkWebResponse();
        }
    }
}
