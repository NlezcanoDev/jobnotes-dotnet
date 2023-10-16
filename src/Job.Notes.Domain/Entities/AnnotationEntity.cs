using Job.Notes.Domain.Enums;

namespace Job.Notes.Domain.Entities;

public class AnnotationEntity: BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public AnnotationTypeEnum AnnotationType { get; set; }
    public int SpaceId { get; set; }
    public SpaceEntity Space { get; set; }
    public ICollection<QuestionEntity> Questions { get; set; }
    public ICollection<ToDoEntity> ToDos { get; set; }
    public ICollection<NoteEntity> Notes { get; set; }
}