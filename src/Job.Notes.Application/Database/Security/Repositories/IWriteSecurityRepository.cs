using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Security.Repositories;

public interface IWriteSecurityRepository
{
    Task<SecurityEntity> Create<TD>(TD data);
}