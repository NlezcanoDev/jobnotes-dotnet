using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Interfaces.User.Commands.UpdatePasswordUser;

public class UpdatePasswordUserCommand: IUpdatePasswordUserCommand
{
    private readonly IDatabaseService _databaseService;

    public UpdatePasswordUserCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<bool> Execute(UpdatePasswordUserModel model)
    {
        var entity = await _databaseService.User
            .FirstOrDefaultAsync(u => u.Id == model.Id);

        if (entity is null) return false;

        entity.Password = model.Password;
        return await _databaseService.SaveAsync();
    }
}