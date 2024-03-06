using Job.Notes.Application.Database.User.Repositories;
using Job.Notes.Application.Models.Filters;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Models;
using Job.Notes.Persistence.Abstractions;
using Job.Notes.Persistence.Database;

namespace Job.Notes.Persistence.Repositories.Read;

public class ReadUserRepository: ReadRepository<UserEntity, BaseFilter>, IReadUserRepository
{
    private readonly DatabaseService _service;
    
    public ReadUserRepository(DatabaseService service) : base(service)
    {
        _service = service;
    }

    public override PaginatedModel<UserEntity> Get(BaseFilter filter)
    {
        throw new NotImplementedException();
    }

    public bool IsUserRepeated(string mail)
    {
       return _service.User.Any(x => x.Mail == mail);
    }
}