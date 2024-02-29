using Job.Notes.Application.Models.Filters;
using Job.Notes.Application.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Project.Repositories;

public interface IReadProjectRepository: IReadRepository<ProjectEntity, ProjectFilter>
{
    bool CheckProjectInProgress(int id);
}