using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Application.Models.Filters;
using Job.Notes.Application.Models.OrderBy;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Models;
using Job.Notes.Persistence.Abstractions;
using Job.Notes.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Repositories.Read;

public class ReadSpaceRepository: ReadRepository<SpaceEntity, SpaceFilter>, IReadSpaceRepository
{
    private readonly DatabaseService _service;
    
    public ReadSpaceRepository(DatabaseService service) : base(service)
    {
        _service = service;
    }

    public override PaginatedModel<SpaceEntity> Get(SpaceFilter filter)
    {
        var pageSize = filter.PageSize ?? 10;
        var currentPage = filter.CurrentPage ?? 1;

        var entities = _service.Space
            .Where(s => s.Enabled && !s.Deleted)
            .AsNoTracking();

        var total = entities.Count();

        entities = entities.Where(s => (string.IsNullOrEmpty(filter.SearchText) || s.Name.StartsWith(filter.SearchText))
                                       && (filter.Status == null || filter.Status.Contains(s.Status)));

        var count = entities.Count();

        switch (filter.OrderBy)
        {
            case SpacesOrderByEnum.Fecha:
                entities = filter.OrderAsc
                    ? entities.OrderBy(s => s.UpdateDate ?? s.CreateDate)
                    : entities.OrderByDescending(s => s.UpdateDate ?? s.CreateDate);
                break;
            case SpacesOrderByEnum.Relevancia:
                entities = entities.OrderBy(s => s.Status);
                break;
            default:
                entities = entities.OrderBy(s => s.Name);
                break;
        }

        var results = entities
            .Skip(pageSize * (currentPage - 1))
            .Take(pageSize);

        return new PaginatedModel<SpaceEntity>
        {
            Total = total,
            Count = count,
            Result = results
        };
    }

    public override async Task<SpaceEntity> GetById(int id)
    {
        var data = await _service.Space
            .FirstOrDefaultAsync(s => s.Id == id);
        if (data is null)
            throw new FileNotFoundException("Data was not found by Id");

        return data;
    }
}