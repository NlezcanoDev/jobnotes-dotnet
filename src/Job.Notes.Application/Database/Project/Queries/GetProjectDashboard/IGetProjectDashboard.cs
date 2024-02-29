using Job.Notes.Application.Models.Filters;

namespace Job.Notes.Application.Database.Project.Queries.GetProjectDashboard;

public interface IGetProjectDashboard
{
    List<GetProjectDashboardModel> Execute();
}