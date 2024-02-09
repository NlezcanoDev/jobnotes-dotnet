using AutoMapper;
using Job.Notes.Application.Database.Space.Repository;
using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Models;
using Job.Notes.Persistence.Abstractions;
using Job.Notes.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Repositories;

public class SpaceRepository : BaseRepository<SpaceEntity, SpaceFilter>, ISpaceRepository
{
    private DatabaseService _service;
    
    public SpaceRepository(DatabaseService service, IMapper mapper) : base(service, mapper)
    {
        _service = service;
    }
    
    public override async Task<PaginatedResponseModel<SpaceEntity>> Get(SpaceFilter filter)
    {
        var pageSize = filter.PageSize ?? 10;
        var currentPage = filter.CurrentPage ?? 1;

        var entities = _service.Space
            .Where(s => s.Enabled && !s.Deleted)
            .AsNoTracking();
            
        var cantSpaces = entities.Count();
        var spaces = await entities
            .Skip(pageSize * (currentPage - 1))
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResponseModel<SpaceEntity>
        {
            Total = cantSpaces,
            Result = spaces
        };
    }

    
}