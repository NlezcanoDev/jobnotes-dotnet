namespace Job.Notes.Domain.Entities;

public class NoteEntity: BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int AnnotationId { get; set; }
}