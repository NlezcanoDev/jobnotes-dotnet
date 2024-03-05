using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Enums;

namespace Job.Notes.Application.Database.Space.Commands.ArchiveSpace;

public class ArchiveSpace: IArchiveSpace
{
    private readonly IWriteSpaceRepository _writeRepository;
    private readonly IReadSpaceRepository _readRepository;

    public ArchiveSpace(IWriteSpaceRepository writeRepository, IReadSpaceRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<SpaceEntity> Execute(int id)
    {
        var entity = await _readRepository.GetById(id);
        var updateObject = new ArchiveSpaceModel
        {
            Enabled = false,
            Deleted = false,
            Status = SpaceStatusEnum.Paused
        };

        if (!entity.TasksLists.Any() && !entity.Notes.Any() && !entity.QuestionsLists.Any())
            updateObject.Deleted = true;

        if (entity.Status == SpaceStatusEnum.Finished)
            updateObject.Status = entity.Status;
            
        return await _writeRepository.PartialUpdate(id, updateObject);
    }
}