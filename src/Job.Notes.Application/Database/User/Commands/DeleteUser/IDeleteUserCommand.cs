namespace Job.Notes.Application.Interfaces.User.Commands.DeleteUser;

public interface IDeleteUserCommand
{
    Task<bool> Execute(int userId);
}