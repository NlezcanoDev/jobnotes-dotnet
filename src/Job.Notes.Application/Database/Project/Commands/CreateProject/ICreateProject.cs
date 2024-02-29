using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Project.Commands.CreateProject;

public interface ICreateProject
{
    Task<ProjectEntity> Execute(ICreateProjectModel model);
}