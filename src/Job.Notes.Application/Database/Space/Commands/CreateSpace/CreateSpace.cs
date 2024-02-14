using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Commands.CreateSpace;

public class CreateSpace: ICreateSpace
{
    private readonly IWriteSpaceRepository _repository;
    
    public CreateSpace(IWriteSpaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<SpaceEntity> Execute(CreateSpaceModel model)
    {
        var entity = await _repository.Create(model);
        return entity;
    }
}