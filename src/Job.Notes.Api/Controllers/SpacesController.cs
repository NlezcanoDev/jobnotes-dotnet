using Job.Notes.Application.Database.Space.Commands.ArchiveSpace;
using Job.Notes.Application.Database.Space.Commands.ChangeStatusSpace;
using Job.Notes.Application.Database.Space.Commands.CreateSpace;
using Job.Notes.Application.Database.Space.Commands.UpdateSpace;
using Job.Notes.Application.Database.Space.Queries.GetSpaceById;
using Job.Notes.Application.Database.Space.Queries.GetSpaces;
using Job.Notes.Application.Database.Space.Queries.GetSpacesDashboard;
using Job.Notes.Domain.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Job.Notes.Api.Controllers;

[Route("api/spaces")]
[ApiController]
public class SpacesController: ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery]SpaceFilter filter,
        [FromServices] IGetSpaces getSpaces)
    {
        var data = await getSpaces.Execute(filter);
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, [FromServices] IGetSpaceById getSpaceById)
    {
        var data = await getSpaceById.Execute(id);
        return Ok(data);
    }
    
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetResume(
        [FromQuery] SpaceFilter filter,
        [FromServices] IGetSpacesDashboard getSpacesDashboard
    )
    {
        var data =  await getSpacesDashboard.Execute(filter);
        return Ok(data);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateSpaceModel model,
        [FromServices] ICreateSpace createSpace)
    {
        var data = await createSpace.Execute(model);
        return Created("/spaces", data);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id, 
        [FromBody]UpdateSpaceModel model,
        [FromServices] IUpdateSpace updateSpace)
    {
        var data = await updateSpace.Execute(id, model);
        return Ok(data);
    }
    
    [HttpPut("archive/{id:int}")]
    public async Task<IActionResult> Archive(
        int id,
        [FromServices] IArchiveSpace archiveSpace)
    {
        await archiveSpace.Execute(id);
        return NoContent();
    }
    
    [HttpPut("changeStatus/{id:int}")]
    public async Task<IActionResult> ChangeStatus(
        int id,
        [FromBody] ChangeStatusSpaceModel model,
        [FromServices] IChangeStatusSpaceCommand changeStatusSpaceCommand
    )
    {
        var data = await changeStatusSpaceCommand.Execute(id, model);
        return Ok(data);
    }
}