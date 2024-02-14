using Job.Notes.Application.Database.Space.Queries.GetSpaces;
using Job.Notes.Application.Database.Space.Queries.GetSpaces.Models;
using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Enums;
using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Response;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Database.Space.Queries.GetSpacesDashboard;

public class GetSpacesDashboard: IGetSpacesDashboard
{
    private readonly IReadSpaceRepository _repository;
    
    public GetSpacesDashboard(IReadSpaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedResponseModel<GetSpacesDashboardModel>> Execute(SpaceFilter filter)
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
                NoteCount = s.Annotations.Count(a => a.AnnotationType == AnnotationTypeEnum.Note),
                QuestionCount = s.Annotations.Count(a => a.AnnotationType == AnnotationTypeEnum.Question),
                ToDoCount = s.Annotations.Count(a => a.AnnotationType == AnnotationTypeEnum.ToDo)
            },
            CreateDate = s.CreateDate,
            UpdateDate = s.UpdateDate
        });
        
        var spaceModelList = await spaceModel.ToListAsync();

        return new PaginatedResponseModel<GetSpacesDashboardModel>
        {
            Total = data.Total,
            Count = data.Count,
            Result = spaceModelList
        };
    }
}