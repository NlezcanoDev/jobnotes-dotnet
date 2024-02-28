using AutoMapper;
using Job.Notes.Application.Database.Space.Repositories.Write;
using Job.Notes.Domain.Entities;
using Job.Notes.Persistence.Abstractions;
using Job.Notes.Persistence.Database;

namespace Job.Notes.Persistence.Repositories.Write;

public class WriteProjectRepository: WriteRepository<ProjectEntity>, IWriteProjectRepository
{
    public WriteProjectRepository(DatabaseService service, IMapper mapper) : base(service, mapper)
    {
    }
}