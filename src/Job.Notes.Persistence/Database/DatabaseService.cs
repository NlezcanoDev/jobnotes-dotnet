using Job.Notes.Application.Database;
using Job.Notes.Domain.Entities;
using Job.Notes.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Database;

public class DatabaseService : DbContext, IDatabaseService
{
    public DatabaseService(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserEntity> User { get; set; }
    public DbSet<ProjectEntity> Project { get; set; }
    public DbSet<SpaceEntity> Space { get; set; }
    public DbSet<QuestionListEntity> QuestionList { get; set; }
    public DbSet<QuestionEntity> Question { get; set; }
    public DbSet<TaskListEntity> TaskList { get; set; }
    public DbSet<TaskEntity> Task { get; set; }
    public DbSet<NoteEntity> Note { get; set; }

    public async Task<bool> SaveAsync()
    {
        return await SaveChangesAsync() > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        EntityConfiguration(modelBuilder);
    }

    private void EntityConfiguration(ModelBuilder modelBuilder)
    {
        new UserConfiguration(modelBuilder.Entity<UserEntity>());
        new ProjectConfiguration(modelBuilder.Entity<ProjectEntity>());
        new SpaceConfiguration(modelBuilder.Entity<SpaceEntity>());
        new QuestionListConfiguration(modelBuilder.Entity<QuestionListEntity>());
        new QuestionConfiguration(modelBuilder.Entity<QuestionEntity>());
        new TaskListConfiguration(modelBuilder.Entity<TaskListEntity>());
        new TaskConfiguration(modelBuilder.Entity<TaskEntity>());
        new NoteConfiguration(modelBuilder.Entity<NoteEntity>());
    }
}