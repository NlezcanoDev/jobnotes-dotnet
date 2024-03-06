using Job.Notes.Application.Database.User.Commands.CreateUser;
using Job.Notes.External.Jwt.GetTokenJwt;
using Job.Notes.External.Jwt.Models;
using Microsoft.AspNetCore.Mvc;

namespace Job.Notes.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserModel model, 
        [FromServices] ICreateUserCommand createUser,
        [FromServices] IGetTokenJwtModel getTokenJwt)
    {
        var data = await createUser.Execute(model);
        var dataToken = new UserCredentialsModel()
        {
            Id = data.Id,
            Mail = data.Mail
        };
        var accessResponse = getTokenJwt.Execute(dataToken);
        return Created("/user", accessResponse);
    }
}
