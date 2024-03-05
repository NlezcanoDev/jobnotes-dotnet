using Job.Notes.Domain.Enums;

namespace Job.Notes.Application.Database.Space.Commands.ArchiveSpace;

public class ArchiveSpaceModel
{
    public bool Enabled { get; set; }
    public bool Deleted { get; set; }
    public SpaceStatusEnum Status { get; set; }
}