namespace Job.Notes.Application.Interfaces.User.Commands.CreateUser;

public interface ICreateUserCommand
{
    Task<CreateUserModel> Execute(CreateUserModel model);
}