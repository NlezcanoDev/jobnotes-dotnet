using Job.Notes.Application.Database.Project.Repositories;

namespace Job.Notes.Application.Database.Project.Commands.DeleteProject;

public class DeleteProject: IDeleteProject
{
    private readonly IWriteProjectRepository _writeRepository;
    private readonly IReadProjectRepository _readRepository;

    public DeleteProject(IWriteProjectRepository writeRepository, IReadProjectRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task Execute(int id)
    {
        var hasOpenProjects = _readRepository.CheckProjectInProgress(id);
        if (hasOpenProjects)
            throw new InvalidOperationException("Project cannot be deleted. There are spaces open.");
        
        await _writeRepository.Delete(id);
    }
}