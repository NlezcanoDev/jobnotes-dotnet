using AutoMapper;
using Job.Notes.Application.Database.Space.Repositories.Write;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Project.Commands.CreateProject;

public class CreateProject: ICreateProject
{
    private readonly IWriteProjectRepository _repository;

    public CreateProject(IWriteProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProjectEntity> Execute(ICreateProjectModel model)
    {
        var entity = await _repository.Create(model);
        return entity;
    }
}