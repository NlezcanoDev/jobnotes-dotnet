using Job.Notes.Application.Models.OrderBy;
using Job.Notes.Domain.Enums;

namespace Job.Notes.Application.Models.Filters;

public class SpaceFilter: BaseFilter
{
    public int? ProjectId { get; set; }
    public SpacesOrderByEnum? OrderBy { get; set; }
    public bool OrderAsc { get; set; } = true;
    public List<SpaceStatusEnum> Status { get; set; }
}