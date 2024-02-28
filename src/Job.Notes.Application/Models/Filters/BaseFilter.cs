namespace Job.Notes.Application.Models.Filters;

public class BaseFilter
{
    public string SearchText { get; set; }
    public int? CurrentPage { get; set; }
    public int? PageSize { get; set; }
}