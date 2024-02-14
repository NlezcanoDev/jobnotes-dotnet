using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Commands.ChangeStatusSpace;

public interface IChangeStatusSpaceCommand
{
    Task<SpaceEntity> Execute(int id, ChangeStatusSpaceModel model);
}