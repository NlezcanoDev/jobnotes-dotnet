using Job.Notes.Application.Database.Space.Repositories;
using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;
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

    public async Task<PaginatedResponseModel<SpaceEntity>> Execute(SpaceFilter filter)
    {
        var data = _repository.Get(filter);
        var result = await  data.Result.ToListAsync();

        return new PaginatedResponseModel<SpaceEntity>
        {
            Total = data.Total,
            Count = data.Count,
            Result = result
        };
    }
}