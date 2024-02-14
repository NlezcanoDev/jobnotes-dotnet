using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Models;

namespace Job.Notes.Application.Repositories;

public interface IReadRepository<TE, TF>
    where TE : BaseEntity
    where TF : BaseFilter

{
    PaginatedModel<TE> Get(TF filter);
    IQueryable<TE> GetAll(int limit);
    Task<TE> GetById(int id);
}