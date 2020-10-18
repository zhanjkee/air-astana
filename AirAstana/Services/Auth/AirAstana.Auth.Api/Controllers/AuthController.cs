using Microsoft.AspNetCore.Mvc;

namespace AirAstana.Auth.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpGet]
        public IActionResult ToDo()
        {
            return Ok("ToDo");
        }
    }
}
