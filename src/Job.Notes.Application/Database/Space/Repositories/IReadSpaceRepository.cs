using Job.Notes.Application.Models.Filters;
using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Repositories;

public interface IReadSpaceRepository: IReadRepository<SpaceEntity, SpaceFilter>
{
}