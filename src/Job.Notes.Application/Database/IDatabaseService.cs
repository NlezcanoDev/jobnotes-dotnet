using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Application.Interfaces;

public interface IDatabaseService
{
    DbSet<UserEntity> User { get; set; }
    DbSet<SpaceEntity> Space { get; set; }
    DbSet<AnnotationEntity> Annotation { get; set; }
    DbSet<QuestionEntity> Question { get; set; }
    DbSet<ToDoEntity> ToDo { get; set; }
    DbSet<NoteEntity> Note { get; set; }

    Task<bool> SaveAsync();
}