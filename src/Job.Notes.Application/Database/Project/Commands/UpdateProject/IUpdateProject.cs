using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Project.Commands.UpdateProject;

public interface IUpdateProject
{
    Task<ProjectEntity> Execute(int id, UpdateProjectModel model);
}