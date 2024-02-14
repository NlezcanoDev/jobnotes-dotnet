namespace Job.Notes.Application.Database.Space.Commands.ArchiveSpace;

public interface IArchiveSpace
{
    Task Execute(int id);
}