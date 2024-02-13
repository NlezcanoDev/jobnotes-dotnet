using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Database.Space.Commands.ArchiveSpace;

public class ArchiveSpaceCommand: IArchiveSpaceCommand
{
    private readonly IDatabaseService _databaseService;

    public ArchiveSpaceCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task Execute(int id)
    {
        var entity = _databaseService.Space.FirstOrDefault(s => s.Id == id);
        if (entity is null)
            throw new FileNotFoundException("Espacio no encontrado");

        entity.Enabled = false;
        entity.UpdateDate = DateTime.Now;
        var result = await _databaseService.SaveAsync();
        if (!result)
            throw new DbUpdateException();
    }
}