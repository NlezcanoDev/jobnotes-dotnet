using AutoMapper;
using Job.Notes.Application.Database.Project.Repositories;
using Job.Notes.Application.Models.Filters;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Project.Queries.GetProjectDashboard;

public class GetProjectDashboard: IGetProjectDashboard
{
    private readonly IMapper _mapper;
    private readonly IReadProjectRepository _repository;

    public GetProjectDashboard(IMapper mapper, IReadProjectRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public List<GetProjectDashboardModel> Execute()
    {
        var data = _repository.GetAll(100);
        return _mapper.Map<List<ProjectEntity>, List<GetProjectDashboardModel>>(data.ToList());
    }
}