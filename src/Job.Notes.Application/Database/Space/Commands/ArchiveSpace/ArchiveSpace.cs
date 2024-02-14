using Job.Notes.Application.Database.Space.Repositories;

namespace Job.Notes.Application.Database.Space.Commands.ArchiveSpace;

public class ArchiveSpace: IArchiveSpace
{
    private readonly IWriteSpaceRepository _repository;

    public ArchiveSpace(IWriteSpaceRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(int id)
    {
        await _repository.PartialUpdate(id, new {Enabled = false});
    }
}