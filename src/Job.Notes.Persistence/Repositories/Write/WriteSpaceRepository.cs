using AutoMapper;
using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Persistence.Abstractions;
using Job.Notes.Persistence.Database;

namespace Job.Notes.Persistence.Repositories.Write;

public class WriteSpaceRepository: WriteRepository<SpaceEntity>, IWriteSpaceRepository
{
    
    public WriteSpaceRepository(DatabaseService service, IMapper mapper) : base(service, mapper)
    {
    }
}