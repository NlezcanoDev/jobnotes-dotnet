using Job.Notes.Domain.Enums;

namespace Job.Notes.Domain.Entities;

public class AnnotationEntity: BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public AnnotationTypeEnum AnnotationType { get; set; }
    public int SpaceId { get; set; }
}