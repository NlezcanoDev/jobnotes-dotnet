using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Database.Space.Commands.ChangeStatusSpace;

public class ChangeStatusSpaceCommand: IChangeStatusSpaceCommand
{
    private readonly IDatabaseService _databaseService;

    public ChangeStatusSpaceCommand(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
    
    public async Task<SpaceEntity> Execute(int id, ChangeStatusSpaceModel model)
    {
        var entity = await _databaseService.Space
            .FirstOrDefaultAsync(s => s.Id == id && s.Enabled && !s.Deleted);

        if (entity is null) 
            throw new FileNotFoundException("No se encontró el espacio seleccionado");

        entity.Status = model.status;
        entity.UpdateDate = DateTime.Now;
        var check = await _databaseService.SaveAsync();
        
        if (!check) throw new DbUpdateException("Error al actualizar espacio");
        
        return entity;
    }
}