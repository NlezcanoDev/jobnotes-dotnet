using AutoMapper;
using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Abstractions;

public abstract class WriteRepository<T>: IWriteRepository<T>
    where T : BaseEntity
{
    private readonly DatabaseService _service;
    private readonly IMapper _mapper;

    protected WriteRepository(DatabaseService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    private DbSet<T> Entities => _service.Set<T>();
    
    public virtual async Task<T> Create<TD>(TD data)
    {
        var entity = _mapper.Map<TD, T>(data);
        if (entity is null)
            throw new ArgumentException("Data value is not assignable to Entity");

        entity.CreateDate = DateTime.Now;
        await Entities.AddAsync(entity);
        
        var result = await _service.SaveAsync();
        if (!result) throw new DbUpdateException();
        
        return entity;
    }

    public virtual async Task<T> Update<TD>(int id, TD data)
    {
        if (data is null) 
            throw new ArgumentNullException(nameof(data), "Data must have a value");
        
        var entity = await Entities.FirstOrDefaultAsync(e => e.Id == id);

        if (entity is null)
            throw new FileNotFoundException("Entity with Id was not found");

        entity = _mapper.Map<TD, T>(data);
        entity.UpdateDate = DateTime.Now;
        
        var result = await _service.SaveAsync();
        if (!result) throw new DbUpdateException();
        
        return entity;
    }

    public virtual async Task<T> PartialUpdate<TD>(int id, TD data)
    {
        if (data is null) 
            throw new ArgumentNullException(nameof(data), "Data must have a value");
        
        var entity = await Entities.FirstOrDefaultAsync(e => e.Id == id);
        
        if (entity is null)
            throw new FileNotFoundException("Entity with Id was not found");
        
        var entry = _service.Entry(entity);
        foreach (var property in data.GetType().GetProperties())
        {
            var newValue = property.GetValue(data);
        
            if (newValue != null)
            {
                entry.Property(property.Name).CurrentValue = newValue;
            }
        }
    
        entity.UpdateDate = DateTime.Now;
        var result = await _service.SaveAsync();
        if (!result) throw new DbUpdateException();
        
        return entity;
    }

    public virtual async Task Delete(int id)
    {
        var entity = await Entities.FirstOrDefaultAsync(e => e.Id == id);
        if (entity is null)
            throw new FileNotFoundException("Entity with Id was not found");

        entity.Deleted = true;
        entity.UpdateDate = DateTime.Now;
        
        await _service.SaveChangesAsync();
    }
}