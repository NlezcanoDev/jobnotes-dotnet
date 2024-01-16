namespace Job.Notes.Application.Interfaces.User.Commands.UpdateUser;

public class UpdateUserModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string ProfileImg { get; set; }
}