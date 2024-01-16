namespace Job.Notes.Application.Interfaces.User.Commands.UpdatePasswordUser;

public interface IUpdatePasswordUserCommand
{
    Task<bool> Execute(UpdatePasswordUserModel model);
}