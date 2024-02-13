using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Enums;

namespace Job.Notes.Application.Database.Space.Commands.ChangeStatusSpace;

public interface IChangeStatusSpaceCommand
{
    Task<SpaceEntity> Execute(int id, ChangeStatusSpaceModel model);
}