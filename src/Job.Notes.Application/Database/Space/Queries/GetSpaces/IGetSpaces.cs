using Job.Notes.Application.Models.Filters;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Models;
using Job.Notes.Domain.Response;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaces;

public interface IGetSpaces
{
    PaginatedModel<SpaceEntity> Execute(SpaceFilter filter);
}