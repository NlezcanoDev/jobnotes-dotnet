using Job.Notes.Application.Database.Space.Queries.GetSpaces.Models;
using Job.Notes.Domain.Enums;

namespace Job.Notes.Application.Database.Space.Queries.GetSpaces;

public class GetSpacesModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SpaceStatusEnum Status { get; set; } 
    public StatsSpaceModel Stats { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}