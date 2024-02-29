namespace Job.Notes.Application.Database.Project.Commands.DeleteProject;

public interface IDeleteProject
{
    Task Execute(int id);
}