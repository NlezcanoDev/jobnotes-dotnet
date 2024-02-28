namespace Job.Notes.Domain.Entities;

public class TaskListEntity: BaseEntity
{
    public string Name { get; set; }
    public int SpaceId { get; set; }
    public SpaceEntity Space { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; }
}