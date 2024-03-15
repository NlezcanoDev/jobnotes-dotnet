using AutoMapper;
using Job.Notes.Application.Database.Security.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Repositories.Write;

public class WriteSecurityRepository: IWriteSecurityRepository
{
    private readonly DatabaseService _service;
    private readonly IMapper _mapper;

    public WriteSecurityRepository(DatabaseService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    
    public async Task<SecurityEntity> Create<TD>(TD data)
    {
        var entity = _mapper.Map<TD, SecurityEntity>(data);
        if (entity is null)
            throw new ArgumentException("Data value is not assignable to Entity");
        
        entity.CreateDate = DateTime.Now;
        await _service.AddAsync(entity);
        
        var result = await _service.SaveAsync();
        if (!result) throw new DbUpdateException();
        
        return entity;
    }
}