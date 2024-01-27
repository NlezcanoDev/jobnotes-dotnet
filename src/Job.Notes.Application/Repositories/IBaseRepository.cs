using Job.Notes.Domain.Entities;
using Job.Notes.Domain.Filters;
using Job.Notes.Domain.Models;

namespace Job.Notes.Application.Repositories;


public interface IBaseRepository<TE, TF>
    where TE : BaseEntity
    where TF : BaseFilter
{
    Task<PaginatedResponseModel<TE>> Get(TF filter);
    IQueryable<TE> GetAll();
    Task<TE> GetById(int id);
    Task<TE> Create<TD>(TD data);
    Task<TE> Update<TD>(int id, TD data);
    Task Delete(int id);
}