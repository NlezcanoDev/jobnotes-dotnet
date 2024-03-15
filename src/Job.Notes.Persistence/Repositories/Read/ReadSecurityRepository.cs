using Job.Notes.Application.Database.Security.Repositories;
using Job.Notes.Application.Models.Filters;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Models;
using Job.Notes.Persistence.Database;

namespace Job.Notes.Persistence.Repositories.Read;

public class ReadSecurityRepository: IReadSecurityRepository
{
    public ReadSecurityRepository(DatabaseService service)
    {
    }

    public PaginatedModel<SecurityEntity> Get(BaseFilter filter)
    {
        throw new NotImplementedException();
    }

    public IQueryable<SecurityEntity> GetAll(int limit)
    {
        throw new NotImplementedException();
    }

    public Task<SecurityEntity> GetById(int id)
    {
        throw new NotImplementedException();
    }
}