namespace Job.Notes.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
}