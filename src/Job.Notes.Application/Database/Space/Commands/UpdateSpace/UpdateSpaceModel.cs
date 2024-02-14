using Job.Notes.Domain.Enums;

namespace Job.Notes.Application.Database.Space.Commands.UpdateSpace;

public class UpdateSpaceModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SpaceStatusEnum Status { get; set; }
}