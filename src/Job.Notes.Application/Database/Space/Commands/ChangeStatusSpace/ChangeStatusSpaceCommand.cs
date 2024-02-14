using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Commands.ChangeStatusSpace;

public class ChangeStatusSpaceCommand: IChangeStatusSpaceCommand
{
    private readonly IWriteSpaceRepository _repository;

    public ChangeStatusSpaceCommand(IWriteSpaceRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<SpaceEntity> Execute(int id, ChangeStatusSpaceModel model)
    {
        var dtoStatus = new ChangeStatusSpaceModel
        {
            Status = model.Status
        };
        
        var entity = await _repository.PartialUpdate(id, dtoStatus);
        return entity;
    }
}