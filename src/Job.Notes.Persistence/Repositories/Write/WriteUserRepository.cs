using AutoMapper;
using Job.Notes.Application.Database.User.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Persistence.Abstractions;
using Job.Notes.Persistence.Database;

namespace Job.Notes.Persistence.Repositories.Write;

public class WriteUserRepository: WriteRepository<UserEntity>, IWriteUserRepository
{
    public WriteUserRepository(DatabaseService service, IMapper mapper) : base(service, mapper)
    {
    }
}