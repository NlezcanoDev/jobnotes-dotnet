namespace Job.Notes.Domain.Entities;

public class QuestionListEntity: BaseEntity
{
    public string Name { get; set; }
    public int SpaceId { get; set; }
    public SpaceEntity Space { get; set; }
    public ICollection<QuestionEntity> Questions { get; set; }
}