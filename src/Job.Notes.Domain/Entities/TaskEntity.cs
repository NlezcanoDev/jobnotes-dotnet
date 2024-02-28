namespace Job.Notes.Domain.Entities;

public class TaskEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
    public int TaskListId { get; set; }
    public TaskListEntity TaskList { get; set; }
}