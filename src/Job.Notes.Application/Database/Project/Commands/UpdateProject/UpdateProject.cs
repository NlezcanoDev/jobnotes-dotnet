using Job.Notes.Application.Database.Project.Repositories;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Project.Commands.UpdateProject;

public class UpdateProject: IUpdateProject
{
    private readonly IWriteProjectRepository _repository;

    public UpdateProject(IWriteProjectRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ProjectEntity> Execute(int id, UpdateProjectModel model)
    {
        var result = await _repository.Update(id, model);
        return result;
    }
}