using Job.Notes.Domain.Enums;

namespace Job.Notes.Domain.Entities;

public class UserEntity: BaseEntity
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Mail { get; set; }
    public UserRoleEnum Role { get; set; }
    public string ProfileImg { get; set; }
}