namespace Job.Notes.Application.Database.Space.Queries.GetSpaceById;

public interface IGetSpaceByIdQuery
{
    Task<GetSpaceByIdModel> Execute(int id);
}