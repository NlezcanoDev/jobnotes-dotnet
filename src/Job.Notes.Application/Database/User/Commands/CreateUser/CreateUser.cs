using Job.Notes.Application.Database.User.Repositories;
using Job.Notes.Application.Security;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.User.Commands.CreateUser;

public class CreateUser: ICreateUser
{
    private readonly IReadUserRepository _readRepository;
    private readonly IWriteUserRepository _writeRepository;

    public CreateUser(
        IReadUserRepository readRepository, 
        IWriteUserRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<UserEntity> Execute(CreateUserModel model)
    {
        var isUserRepeated = _readRepository.IsUserDuplicated(model.Mail);
        if (isUserRepeated) throw new ArgumentException("User is already existing");
        
        var entity = await _writeRepository.Create(model);
        return entity;
    }
}