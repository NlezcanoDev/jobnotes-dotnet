namespace Job.Notes.Application.Database.User.Commands.CreateUsername;

public interface ICreateUsername
{
    Task Execute(CreateUsernameModel model);
}