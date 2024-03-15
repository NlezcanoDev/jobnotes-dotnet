namespace Job.Notes.Application.Database.User.Commands.CreateUsername;

public class CreateUsernameModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public bool Enabled { get; set; }
}