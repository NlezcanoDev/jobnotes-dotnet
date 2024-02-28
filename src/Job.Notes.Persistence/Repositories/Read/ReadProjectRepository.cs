using Job.Notes.Application.Database.Project.Repositories;
using Job.Notes.Application.Models.Filters;
using Job.Notes.Application.Models.OrderBy;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Enums;
using Job.Notes.Domain.Models;
using Job.Notes.Persistence.Abstractions;
using Job.Notes.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Repositories.Read;

public class ReadProjectRepository: ReadRepository<ProjectEntity, ProjectFilter>, IReadProjectRepository
{
    private readonly DatabaseService _service;
    
    public ReadProjectRepository(DatabaseService service) : base(service)
    {
        _service = service;
    }

    public override PaginatedModel<ProjectEntity> Get(ProjectFilter filter)
    {
        var pageSize = filter.PageSize ?? 10;
        var currentPage = filter.CurrentPage ?? 1;
        
        var entities = _service.Project
            .Where(p => p.Enabled && !p.Deleted)
            .AsNoTracking();
        
        var total = entities.Count();

        entities = entities
            .Where(p => (string.IsNullOrEmpty(filter.SearchText) || p.Name.StartsWith(filter.SearchText)));

        switch (filter.OrderBy)
        {
            case ProjectOrderByEnum.Fecha:
                entities = filter.OrderAsc
                    ? entities.OrderBy(p => p.UpdateDate ?? p.CreateDate)
                    : entities.OrderByDescending(p => p.UpdateDate ?? p.CreateDate);
                break;
            case ProjectOrderByEnum.Alfabeticamente:
                entities = filter.OrderAsc
                    ? entities.OrderBy(p => p.Name)
                    : entities.OrderByDescending(p => p.Name);
                break;
            default:
                entities = entities.OrderBy(p => p.Name);
                break;
        }
        
        var count = entities.Count();
        var results = entities
            .Skip(pageSize * (currentPage - 1))
            .Take(pageSize);
        
        
        return new PaginatedModel<ProjectEntity>
        {
            Total = total,
            Count = count,
            Result = results
        };
    }

    public bool CheckProjectInProgress(int id)
    {
        var spacesAvailable = _service.Space
            .Where(s => !s.Deleted && s.Enabled && s.Status != SpaceStatusEnum.Finished)
            .Count(s => s.ProjectId == id);

        return spacesAvailable > 0;
    }
}