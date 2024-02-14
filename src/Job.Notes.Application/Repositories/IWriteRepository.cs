using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Repositories;

public interface IWriteRepository<TE> where TE : BaseEntity
{
    Task<TE> Create<TD>(TD data);
    Task<TE> Update<TD>(int id, TD data);
    Task<TE> PartialUpdate<TD>(int id, TD data);
    Task Delete(int id);
}