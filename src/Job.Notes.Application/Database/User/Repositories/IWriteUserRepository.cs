using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.User.Repositories;

public interface IWriteUserRepository: IWriteRepository<UserEntity>
{
    
}