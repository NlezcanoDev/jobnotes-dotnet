using Job.Notes.Application.Database.User.Repositories;

namespace Job.Notes.Application.Database.User.Commands.CreateUsername;

public class CreateUsername: ICreateUsername
{
    private readonly IReadUserRepository _readRepository;
    private readonly IWriteUserRepository _writeRepository;

    public CreateUsername(IReadUserRepository readRepository, IWriteUserRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Execute(CreateUsernameModel model)
    {
        var user = await _readRepository.GetInactiveUserById(model.Id);
        if (user is null)
            throw new FileNotFoundException("It is not possible to assign username to this user");

        model.Enabled = true;

        await _writeRepository.PartialUpdate(user.Id, model);
    }
}