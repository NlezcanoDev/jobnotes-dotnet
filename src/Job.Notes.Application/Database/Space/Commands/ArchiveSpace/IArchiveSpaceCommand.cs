namespace Job.Notes.Application.Database.Space.Commands.ArchiveSpace;

public interface IArchiveSpaceCommand
{
    Task Execute(int id);
}