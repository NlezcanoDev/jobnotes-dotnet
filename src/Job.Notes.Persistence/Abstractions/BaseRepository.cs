using AutoMapper;
using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Models;
using Job.Notes.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Abstractions;

public abstract class BaseRepository<T, TF> : IBaseRepository<T, TF>
    where T : BaseEntity
    where TF : BaseFilter
{
    private readonly DatabaseService _service;
    private readonly IMapper _mapper;

    protected BaseRepository(DatabaseService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    private DbSet<T> Entities => _service.Set<T>();

    public abstract Task<PaginatedResponseModel<T>> Get(TF filter);

    public IQueryable<T> GetAll()
    {
        return Entities.Take(100).AsQueryable();
    }

    public async Task<T> GetById(int id)
    {
        var entity = await Entities.FirstOrDefaultAsync(e => e.Id == id);
        if (entity is null)
            throw new FileNotFoundException("Entity with Id was not found");

        return entity;
    }

    public async Task<T> Create<TD>(TD data)
    {
        var entity = _mapper.Map<TD, T>(data);
        if (entity is null)
            throw new ArgumentException("Data value is not assignable to Entity");

        entity.CreateDate = DateTime.Now;
        await Entities.AddAsync(entity);
        await _service.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Update<TD>(int id, TD data)
    {
        if (data is null) 
            throw new ArgumentNullException(nameof(data), "Data must have a value");
        
        var entity = await Entities.FirstOrDefaultAsync(e => e.Id == id);

        if (entity is null)
            throw new FileNotFoundException("Entity with Id was not found");

        entity = _mapper.Map<TD, T>(data);
        entity.UpdateDate = DateTime.Now;
        await _service.SaveAsync();
        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await Entities.FirstOrDefaultAsync(e => e.Id == id);
        if (entity is null)
            throw new FileNotFoundException("Entity with Id was not found");

        entity.Deleted = true;
        entity.UpdateDate = DateTime.Now;
        
        await _service.SaveChangesAsync();
    }
}