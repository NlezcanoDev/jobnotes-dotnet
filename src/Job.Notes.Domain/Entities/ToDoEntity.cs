namespace Job.Notes.Domain.Entities;

public class ToDoEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
    public int AnnotationId { get; set; }
    public AnnotationEntity Annotation { get; set; }
}