using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;

namespace Job.Notes.Application.Database.Space.Repository;

public interface ISpaceRepository : IBaseRepository<SpaceEntity, SpaceFilter>
{
}