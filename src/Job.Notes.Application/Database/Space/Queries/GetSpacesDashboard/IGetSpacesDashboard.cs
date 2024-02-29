using Job.Notes.Application.Models.Filters;
using Job.Notes.Domain.Models;
using Job.Notes.Domain.Response;

namespace Job.Notes.Application.Database.Space.Queries.GetSpacesDashboard;

public interface IGetSpacesDashboard
{
    PaginatedModel<GetSpacesDashboardModel> Execute(SpaceFilter filter);
}