using Job.Notes.Domain.Enums;

namespace Job.Notes.Application.Database.Space.Commands.ChangeStatusSpace;

public class ChangeStatusSpaceModel
{
    public SpaceStatusEnum Status { get; set; }
}