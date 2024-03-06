using Job.Notes.Application.Models.Filters;
using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.User.Repositories;

public interface IReadUserRepository: IReadRepository<UserEntity, BaseFilter>
{
    public bool IsUserRepeated(string mail);
}