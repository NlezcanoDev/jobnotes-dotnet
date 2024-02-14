using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;

namespace Job.Notes.Application.Database.Space.Repositories;

public interface IReadSpaceRepository: IReadRepository<SpaceEntity, SpaceFilter>
{
}