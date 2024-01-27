using Job.Notes.Application.Database.Space.Queries.GetSpaces;
using Job.Notes.Application.Database.Space.Repository;
using Job.Notes.Application.Database.Space.Repository.Models;
using Job.Notes.Application.Features;
using Job.Notes.Domain.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Job.Notes.Api.Controllers;

[Route("api/v1/spaces")]
[ApiController]
public class SpacesController: ControllerBase
{
    private readonly ISpaceRepository _repository;

    public SpacesController(ISpaceRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery]SpaceFilter filter
        //[FromServices] IGetSpacesQuery getSpacesQuery
        )
    {
        var data = await _repository.Get(filter);
        var status = StatusCodes.Status200OK;
        
        return StatusCode(status, ResponseApiService.Response(status, data));
    }

    [HttpGet("resume")]
    public async Task<IActionResult> GetResume(
        [FromQuery] SpaceFilter filter,
        [FromServices] IGetSpacesQuery getSpacesQuery
    )
    {
        var data =  await getSpacesQuery.Execute(filter);
        var status = StatusCodes.Status200OK;
        
        return StatusCode(status, ResponseApiService.Response(status, data));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _repository.GetById(id);
        var status = StatusCodes.Status200OK;

        return StatusCode(status, ResponseApiService.Response(status, data));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSpaceModel model)
    {
        var data = await _repository.Create(model);
        var status = StatusCodes.Status201Created;
        return StatusCode(status, ResponseApiService.Response(status, data));
    }
    
}