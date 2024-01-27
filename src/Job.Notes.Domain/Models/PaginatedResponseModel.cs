namespace Job.Notes.Domain.Models;

public class PaginatedResponseModel<T>
{
    public int Count { get; set; }
    public ICollection<T> Result { get; set; }
}