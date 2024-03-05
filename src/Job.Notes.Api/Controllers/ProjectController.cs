using Job.Notes.Application.Database.Project.Commands.ArchiveProject;
using Job.Notes.Application.Database.Project.Commands.CreateProject;
using Job.Notes.Application.Database.Project.Commands.DeleteProject;
using Job.Notes.Application.Database.Project.Commands.UpdateProject;
using Job.Notes.Application.Database.Project.Queries.GetProjectDashboard;
using Microsoft.AspNetCore.Mvc;

namespace Job.Notes.Api.Controllers;

[Route("api/v1/projects")]
[ApiController]
public class ProjectController : ControllerBase
{
    [HttpGet("dashboard")]
    public IActionResult GetDashboard([FromServices] IGetProjectDashboard getProjectDashboard)
    {
        var data = getProjectDashboard.Execute();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] ICreateProjectModel model, 
        [FromServices] ICreateProject createProject)
    {
        var data = await createProject.Execute(model);
        return Created("/project", data);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateProjectModel model,
        [FromServices] IUpdateProject updateProject)
    {
        var data = await updateProject.Execute(id, model);
        return Ok(data);
    }

    [HttpPut("archive/{id:int}")]
    public async Task<IActionResult> Archive(int id, [FromServices] IArchiveProject archiveProject)
    {
        await archiveProject.Execute(id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<NoContentResult> Delete(int id, [FromServices] IDeleteProject deleteProject)
    {
        await deleteProject.Execute(id);
        return NoContent();
    }
    
}