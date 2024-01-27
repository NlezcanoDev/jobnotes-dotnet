using Job.Notes.Application.Database.Space.Queries.GetSpaces.Models;
using Job.Notes.Domain.Enums;
using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaces;

public class GetSpacesQuery: IGetSpacesQuery
{
    private readonly IDatabaseService _databaseService;
    
    public GetSpacesQuery(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<PaginatedResponseModel<GetSpacesModel>> Execute(BaseFilter filter)
    {
        var pageSize = filter.PageSize ?? 10;
        var currentPage = filter.CurrentPage ?? 1;

        var spaces = _databaseService.Space
            .Where(s => s.Enabled && !s.Deleted)
            .AsNoTracking();
            
        var cantSpaces = spaces.Count();
        
        spaces = spaces
            .Skip(pageSize * (currentPage - 1))
            .Take(pageSize);

        if (filter.SearchText is not null) 
            spaces = spaces.Where(s => s.Name.StartsWith(filter.SearchText));
        
        var spaceModelList = await spaces.Select(s => new GetSpacesModel()
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
                })
            .ToListAsync();

        return new PaginatedResponseModel<GetSpacesModel>
        {
            Count = cantSpaces,
            Result = spaceModelList
        };
    }
}