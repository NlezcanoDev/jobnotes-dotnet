using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Commands.UpdateSpace;

public class UpdateSpace: IUpdateSpace
{
    private readonly IWriteSpaceRepository _repository;

    public UpdateSpace(IWriteSpaceRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<SpaceEntity> Execute(int id, UpdateSpaceModel model)
    {
        var result =await _repository.Update(id, model);
        return result;
    }
}