namespace Job.Notes.Domain.Entities;

public class RegistrationSecurityEntity
{
    public int Id { get; set; }
    public string Mail { get; set; }
    public int Code { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public bool Enabled { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}