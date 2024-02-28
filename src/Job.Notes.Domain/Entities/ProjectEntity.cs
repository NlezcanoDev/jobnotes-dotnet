namespace Job.Notes.Domain.Entities;

public class ProjectEntity: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<SpaceEntity> Spaces { get; set; }
}