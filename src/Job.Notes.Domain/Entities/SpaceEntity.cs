using Job.Notes.Domain.Enums;

namespace Job.Notes.Domain.Entities;

public class SpaceEntity: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SpaceStatusEnum Status { get; set; }
}