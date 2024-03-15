using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.User.Commands.CreateUser;

public interface ICreateUser
{
    Task<UserEntity> Execute(CreateUserModel model);
}