namespace Job.Notes.Domain.Entities;

public class SecurityEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public string Password { get; set; }
    public DateTime? SuccessLoginDate { get; set; }
    public int FailedAttempts { get; set; }
    public DateTime? FailedAttemptDate { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}