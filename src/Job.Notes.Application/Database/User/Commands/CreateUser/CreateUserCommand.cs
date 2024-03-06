using Job.Notes.Application.Database.User.Repositories;
using Job.Notes.Application.Security;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.User.Commands.CreateUser;

public class CreateUserCommand: ICreateUserCommand
{
    private readonly IReadUserRepository _readRepository;
    private readonly IWriteUserRepository _writeRepository;

    public CreateUserCommand(
        IReadUserRepository readRepository, 
        IWriteUserRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<UserEntity> Execute(CreateUserModel model)
    {
        var isUserRepeated = _readRepository.IsUserRepeated(model.Mail);

        if (isUserRepeated)
            throw new ArgumentException("User is already existing");
        
        model.Password = HashService.GenerateSha256Hash(model.Password);
        var entity = await _writeRepository.Create(model);
        
        return entity;
    }
}