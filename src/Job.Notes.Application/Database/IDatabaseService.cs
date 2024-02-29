#nullable enable
using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Database;

public interface IDatabaseService
{
    DbSet<UserEntity> User { get; set; }
    DbSet<ProjectEntity> Project { get; set; }
    DbSet<SpaceEntity> Space { get; set; }
    DbSet<QuestionListEntity> QuestionList { get; set; }
    DbSet<QuestionEntity> Question { get; set; }
    DbSet<TaskListEntity> TaskList { get; set; }
    DbSet<TaskEntity> Task { get; set; }
    DbSet<NoteEntity> Note { get; set; }

    Task<bool> SaveAsync();
}