using Job.Notes.Domain.Enums;

namespace Job.Notes.Application.Interfaces.User.Commands.CreateUser;

public class CreateUserModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRoleEnum Role { get; set; }
}