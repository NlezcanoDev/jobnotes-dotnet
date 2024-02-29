using Job.Notes.Application.Database.Project.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Project.Commands.ArchiveProject;

public class ArchiveProject: IArchiveProject
{
    private readonly IWriteProjectRepository _repository;

    public ArchiveProject(IWriteProjectRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ProjectEntity> Execute(int id)
    {
        return await _repository.PartialUpdate(id, new {Enabled = false});
    }
}