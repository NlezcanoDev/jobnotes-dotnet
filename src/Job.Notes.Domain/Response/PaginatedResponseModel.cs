namespace Job.Notes.Domain.Response;

public class PaginatedResponseModel<T>
{
    public int Total { get; set; }
    public int Count { get; set; }
    public ICollection<T> Result { get; set; }
    public dynamic Stats { get; set; }
}