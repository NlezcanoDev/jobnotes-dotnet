using AutoMapper;
using Job.Notes.Application.Database.User.Repositories;
using Job.Notes.Application.Utils;
using Job.Notes.Domain.Entities;
using Job.Notes.Persistence.Abstractions;
using Job.Notes.Persistence.Database;

namespace Job.Notes.Persistence.Repositories.Write;

public class WriteUserRepository: WriteRepository<UserEntity>, IWriteUserRepository
{
    private readonly DatabaseService _service;
    private readonly IMapper _mapper;

    public WriteUserRepository(DatabaseService service, IMapper mapper) : base(service, mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    public override async Task<UserEntity> Create<TD>(TD data)
    {
        var entity =  _mapper.Map<TD, UserEntity>(data);
        
        if (entity is null)
            throw new ArgumentException("Data value is not assignable to Entity");

        entity.Username = UsernameGenerator.Generate(entity.Name, entity.Lastname, entity.Mail);
        entity.Enabled = false;
        entity.CreateDate = DateTime.Now;
        
        await _service.User.AddAsync(entity);
        await _service.SaveAsync();
        return entity;
    }
}