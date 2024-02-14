namespace Job.Notes.Application.Database.Space.Queries.GetSpaceById;

public interface IGetSpaceById
{
    Task<GetSpaceByIdModel> Execute(int id);
}