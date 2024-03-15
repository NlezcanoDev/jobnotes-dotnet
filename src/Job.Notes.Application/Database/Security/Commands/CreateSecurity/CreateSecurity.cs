using AutoMapper;
using Job.Notes.Application.Database.Security.Repositories;
using Job.Notes.Application.Security;

namespace Job.Notes.Application.Database.Security.Commands.CreateSecurity;

public class CreateSecurity: ICreateSecurity
{
    private readonly IWriteSecurityRepository _writeRepository;

    public CreateSecurity(IWriteSecurityRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task Execute(int id, string password)
    {
        var model = new CreateSecurityModel()
        {
            UserId = id,
            Password = HashService.GenerateSha256Hash(password)
        };
        await _writeRepository.Create(model);
    }
}