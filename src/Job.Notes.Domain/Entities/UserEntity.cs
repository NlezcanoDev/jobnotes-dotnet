﻿namespace Job.Notes.Domain.Entities;

public class UserEntity: BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
    public string ProfileImg { get; set; }
}