using Job.Notes.Domain.Enums;
using Job.Notes.Domain.Enums.Order;

namespace Job.Notes.Domain.Filters;

public class SpaceFilter: BaseFilter
{
    public SpacesOrderByEnum? OrderBy { get; set; }
    public bool OrderAsc { get; set; } = true;
    public List<SpaceStatusEnum> Status { get; set; }
}