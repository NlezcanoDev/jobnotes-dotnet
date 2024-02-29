namespace Job.Notes.Application.Database.User.Commands.CreateUser;

public interface ICreateUserCommand
{
    Task<CreateUserModel> Execute(CreateUserModel model);
}