using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.User.Commands.CreateUser;

public interface ICreateUserCommand
{
    Task<UserEntity> Execute(CreateUserModel model);
}