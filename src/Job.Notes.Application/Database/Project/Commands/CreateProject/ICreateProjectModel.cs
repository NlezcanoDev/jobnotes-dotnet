namespace Job.Notes.Application.Database.Project.Commands.CreateProject;

public interface ICreateProjectModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}