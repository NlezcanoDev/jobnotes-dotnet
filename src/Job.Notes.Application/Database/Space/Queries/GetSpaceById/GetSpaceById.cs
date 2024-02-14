using AutoMapper;
using Job.Notes.Application.Database.Space.Repositories;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaceById;

public class GetSpaceById: IGetSpaceById
{
    private readonly IReadSpaceRepository _repository;
    private readonly IMapper _mapper;

    public GetSpaceById(IReadSpaceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetSpaceByIdModel> Execute(int id)
    {
        var entity = await _repository.GetById(id);
        return _mapper.Map<GetSpaceByIdModel>(entity);
    }
    
}