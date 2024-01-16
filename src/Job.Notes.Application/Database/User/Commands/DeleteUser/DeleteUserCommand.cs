
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Interfaces.User.Commands.DeleteUser;

public class DeleteUserCommand: IDeleteUserCommand
{
    private readonly IDatabaseService _databaseService;
    
    public DeleteUserCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }


    public async Task<bool> Execute(int userId)
    {
        var entity = await _databaseService.User.FirstOrDefaultAsync(u => u.Id == userId);
        if (entity is null) return false;

        entity.Deleted = true;
        return await _databaseService.SaveAsync();
    }
}