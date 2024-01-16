namespace Job.Notes.Application.Interfaces.Base.Commands;

public interface ICreateBaseCommand<TD>
{
    Task<TD> Execute(TD model);
}
