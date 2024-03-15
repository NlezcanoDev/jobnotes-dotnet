using Job.Notes.Application.Database.Security.Commands.CreateSecurity;
using Job.Notes.Application.Database.User.Commands.CreateUser;
using Job.Notes.Application.Database.User.Commands.CreateUsername;
using Microsoft.AspNetCore.Mvc;

namespace Job.Notes.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserModel model, 
        [FromServices] ICreateUser createUser,
        [FromServices] ICreateSecurity createSecurity)
    {
        var data = await createUser.Execute(model);
        await createSecurity.Execute(data.Id, model.Password);
        
        return Created("/user", data);
    }

    [HttpPost("createUsername")]
    public async Task<IActionResult> CreateUsername(
        [FromBody] CreateUsernameModel model,
        [FromServices] ICreateUsername createUsername)
    {
        await createUsername.Execute(model);
        return Created("/security", null);
    }
}
