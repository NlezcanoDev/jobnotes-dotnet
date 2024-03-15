namespace Job.Notes.Domain.Entities;

public class AuthEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public string Salt { get; set; }
    public string Hash { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool Enabled { get; set; }
}