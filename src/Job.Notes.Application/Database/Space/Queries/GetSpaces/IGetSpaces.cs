using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Response;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaces;

public interface IGetSpaces
{
    Task<PaginatedResponseModel<SpaceEntity>> Execute(SpaceFilter filter);
}