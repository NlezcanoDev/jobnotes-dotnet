using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Application.Models.Filters;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Models;
using Job.Notes.Domain.Response;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaces;

public class GetSpaces: IGetSpaces
{
    private readonly IReadSpaceRepository _repository;
    
    public GetSpaces(IReadSpaceRepository repository)
    {
        _repository = repository;
    }

    public PaginatedModel<SpaceEntity> Execute(SpaceFilter filter)
    {
        var data = _repository.Get(filter);
        return data;
    }
}