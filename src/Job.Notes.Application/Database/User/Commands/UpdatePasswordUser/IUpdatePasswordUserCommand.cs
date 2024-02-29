namespace Job.Notes.Application.Database.User.Commands.UpdatePasswordUser;

public interface IUpdatePasswordUserCommand
{
    Task<bool> Execute(UpdatePasswordUserModel model);
}