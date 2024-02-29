using Job.Notes.Application.Database.Space.Queries.GetSpacesDashboard.Models;
using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Application.Models.Filters;
using Job.Notes.Domain.Models;

namespace Job.Notes.Application.Database.Space.Queries.GetSpacesDashboard;

public class GetSpacesDashboard: IGetSpacesDashboard
{
    private readonly IReadSpaceRepository _repository;
    
    public GetSpacesDashboard(IReadSpaceRepository repository)
    {
        _repository = repository;
    }

    public PaginatedModel<GetSpacesDashboardModel> Execute(SpaceFilter filter)
    {
        var data = _repository.Get(filter);
        var spaceModel = data.Result.Select(s => new GetSpacesDashboardModel()
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Status = s.Status,
            Stats = new StatsSpaceModel
            {
                NoteCount = s.Notes.Count(),
                QuestionCount = s.QuestionList.Count(),
                TaskCount = s.TaskList.Count()
            },
            CreateDate = s.CreateDate,
            UpdateDate = s.UpdateDate
        });

        return new PaginatedModel<GetSpacesDashboardModel>
        {
            Total = data.Total,
            Count = data.Count,
            Result = spaceModel
        };
    }
}