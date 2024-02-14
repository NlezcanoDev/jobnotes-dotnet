using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Database.Space.Commands.UpdateSpace;

public interface IUpdateSpace
{
    Task<SpaceEntity> Execute(int id, UpdateSpaceModel model);
}