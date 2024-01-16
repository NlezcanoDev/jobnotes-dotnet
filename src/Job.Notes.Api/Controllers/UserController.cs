using Job.Notes.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Job.Notes.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Test()
        {
            var status = StatusCodes.Status200OK;
            return StatusCode(
                status, 
                ResponseApiService.Response(status, "{}", "Ejecucion exitosa")
                ); 
        }
    }
}
