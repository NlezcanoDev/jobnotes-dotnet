namespace Job.Notes.Application.Database.Space.Queries.GetSpaceById.Models;

public class AnnotationModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int AnnotationType { get; set; }
    public bool Enabled { get; set; }
    public bool Deleted { get; set; }
}