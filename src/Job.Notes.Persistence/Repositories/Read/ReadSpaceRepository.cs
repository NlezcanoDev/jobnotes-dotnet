using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Enums.Order;
using Job.Notes.Domain.Filters;
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

        if (filter.OrderBy is not null)
        {
            if (filter.OrderBy == SpacesOrderByEnum.Relevancia)
                entities = entities.OrderBy(s => s.Annotations.Count);
            else if (filter.OrderBy == SpacesOrderByEnum.Fecha && filter.OrderAsc)
                entities = entities.OrderBy(s => s.UpdateDate ?? s.CreateDate);
            else
                entities = entities.OrderByDescending(s => s.UpdateDate ?? s.CreateDate);
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
            .Include(s => s.Annotations)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (data is null)
            throw new FileNotFoundException("Data was not found by Id");

        return data;
    }
}