using AutoMapper;
using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Interfaces.Base.Commands;

public class CreateBaseCommand<TE, TD> : ICreateBaseCommand<TD> where TE: BaseEntity
{
    private readonly DbContext _context;
    private readonly IMapper _mapper;
    
    public CreateBaseCommand(DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<TD> Execute(TD model)
    {
        var entity = _mapper.Map<TE>(model);
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return model;
    }
}