using Job.Notes.Application.Database.Space.Queries.GetSpaceById.Models;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaceById;

public class GetSpaceByIdModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public ICollection<AnnotationModel> Annotations { get; set; }
}