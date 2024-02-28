namespace Job.Notes.Domain.Entities;

public class NoteEntity: BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int SpaceId { get; set; }
    public SpaceEntity Space { get; set; }
}