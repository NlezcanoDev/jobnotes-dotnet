using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Project.Commands.ArchiveProject;

public interface IArchiveProject
{
    Task<ProjectEntity> Execute(int id);
}