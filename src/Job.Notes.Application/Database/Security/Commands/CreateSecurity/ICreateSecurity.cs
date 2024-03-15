namespace Job.Notes.Application.Database.Security.Commands.CreateSecurity;

public interface ICreateSecurity
{
    Task Execute(int id, string password);
}