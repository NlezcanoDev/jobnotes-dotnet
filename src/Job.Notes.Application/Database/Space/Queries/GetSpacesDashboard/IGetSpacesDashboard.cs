using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Response;

namespace Job.Notes.Application.Database.Space.Queries.GetSpacesDashboard;

public interface IGetSpacesDashboard
{
    Task<PaginatedResponseModel<GetSpacesDashboardModel>> Execute(SpaceFilter filter);
}