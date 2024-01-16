namespace Job.Notes.Application.Interfaces.User.Commands.UpdateUser;

public interface IUpdateUserCommand
{
    Task<UpdateUserModel> Execute(UpdateUserModel model);
}