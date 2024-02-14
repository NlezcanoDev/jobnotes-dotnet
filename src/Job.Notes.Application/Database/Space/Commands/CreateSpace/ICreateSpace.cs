using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Commands.CreateSpace;

public interface ICreateSpace
{
    Task<SpaceEntity> Execute(CreateSpaceModel model);
}