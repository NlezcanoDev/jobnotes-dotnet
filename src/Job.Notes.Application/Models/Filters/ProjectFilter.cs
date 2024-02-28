using Job.Notes.Application.Models.OrderBy;

namespace Job.Notes.Application.Models.Filters;

public class ProjectFilter: BaseFilter
{
    public ProjectOrderByEnum? OrderBy { get; set; }
    public bool OrderAsc { get; set; }
}