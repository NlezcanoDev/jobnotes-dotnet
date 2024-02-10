using Job.Notes.Application.Database.Space.Queries.GetSpaces.Models;
using Job.Notes.Domain.Enums;
using Job.Notes.Domain.Enums.Order;
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

    public async Task<PaginatedResponseModel<GetSpacesModel>> Execute(SpaceFilter filter)
    {
        var pageSize = filter.PageSize ?? 10;
        var currentPage = filter.CurrentPage ?? 1;

        var spaces = _databaseService.Space
            .Where(s => s.Enabled && !s.Deleted)
            .AsNoTracking();
            
        var totalSpaces = spaces.Count();

        spaces = spaces.Where(s => s.Name.StartsWith(filter.SearchText) 
                        && filter.SearchText == null || filter.Status.Contains(s.Status));

        var cantSpacesFiltered = spaces.Count();

        spaces = spaces
            .Skip(pageSize * (currentPage - 1))
            .Take(pageSize);
        
        var spaceModel = spaces.Select(s => new GetSpacesModel()
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
        
        if (filter.OrderBy is not null)
        {
            if(filter.OrderBy == SpacesOrderByEnum.Relevancia)
                spaceModel = spaceModel.OrderBy(s => s.Stats.NoteCount + s.Stats.ToDoCount + s.Stats.QuestionCount);
            else if (filter.OrderBy == SpacesOrderByEnum.Fecha && filter.OrderAsc)
                spaceModel = spaceModel.OrderBy(s => s.UpdateDate ?? s.CreateDate);
            else
                spaceModel = spaceModel.OrderByDescending(s => s.UpdateDate ?? s.CreateDate);
        }

        var spaceModelList = await spaceModel.ToListAsync();

        return new PaginatedResponseModel<GetSpacesModel>
        {
            Total = totalSpaces,
            Count = cantSpacesFiltered,
            Result = spaceModelList
        };
    }
}