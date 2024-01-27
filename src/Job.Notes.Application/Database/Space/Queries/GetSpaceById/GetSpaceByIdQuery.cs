using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaceById;

public class GetSpaceByIdQuery: IGetSpaceByIdQuery
{
    private readonly IDatabaseService _databaseService;
    private readonly IMapper _mapper;

    public GetSpaceByIdQuery(IDatabaseService databaseService, IMapper mapper)
    {
        _databaseService = databaseService;
        _mapper = mapper;
    }

    public async Task<GetSpaceByIdModel> Execute(int id)
    {
        var entity = await _databaseService.Space
            .Include(s => s.Annotations)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (entity is null) throw new FileNotFoundException();

        return _mapper.Map<GetSpaceByIdModel>(entity);
    }
    
}