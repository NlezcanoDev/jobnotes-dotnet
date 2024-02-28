using Job.Notes.Domain.Enums;

namespace Job.Notes.Domain.Entities;

public class SpaceEntity: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SpaceStatusEnum Status { get; set; }
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; }
    public ICollection<TaskListEntity> TaskList { get; set; }
    public ICollection<QuestionListEntity> QuestionList { get; set; }
    public ICollection<NoteEntity> Notes { get; set; }
}