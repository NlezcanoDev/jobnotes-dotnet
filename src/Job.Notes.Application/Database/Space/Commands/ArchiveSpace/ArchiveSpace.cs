using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Commands.ArchiveSpace;

public class ArchiveSpace: IArchiveSpace
{
    private readonly IWriteSpaceRepository _repository;

    public ArchiveSpace(IWriteSpaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<SpaceEntity> Execute(int id)
    {
        return await _repository.PartialUpdate(id, new {Enabled = false});
    }
}