using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Models;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaces;

public interface IGetSpacesQuery
{
    Task<PaginatedResponseModel<GetSpacesModel>> Execute(SpaceFilter filter);
}