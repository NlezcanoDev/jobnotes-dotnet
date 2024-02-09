namespace Job.Notes.Domain.Models;

public class PaginatedResponseModel<T>
{
    public int Total { get; set; }
    public ICollection<T> Result { get; set; }
    public dynamic Stats { get; set; }
}