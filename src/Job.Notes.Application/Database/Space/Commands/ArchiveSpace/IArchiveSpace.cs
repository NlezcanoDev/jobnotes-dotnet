using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Commands.ArchiveSpace;

public interface IArchiveSpace
{
    Task<SpaceEntity> Execute(int id);
}