using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Models;
using Job.Notes.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Abstractions;

public abstract class ReadRepository<T, TF>: IReadRepository<T, TF>
    where T : BaseEntity
    where TF : BaseFilter
{
    private readonly DatabaseService _service;

    protected ReadRepository(DatabaseService service)
    {
        _service = service;
    }
    
    private DbSet<T> Entities => _service.Set<T>();

    public abstract PaginatedModel<T> Get(TF filter);

    public virtual IQueryable<T> GetAll(int limit = 100)
    {
        return Entities.Take(limit).AsNoTracking().AsQueryable();
    }

    public virtual async Task<T> GetById(int id)
    {
        var entity = await Entities
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        
        if (entity is null)
            throw new FileNotFoundException("Entity with Id was not found");

        return entity;
    }
}