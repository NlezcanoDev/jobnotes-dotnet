using Job.Notes.Application.Interfaces;
using Job.Notes.Domain.Entities;
using Job.Notes.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Job.Notes.Persistence.Database;

public class DatabaseService: DbContext,IDatabaseService
{
    public DatabaseService(DbContextOptions options): base(options)
    {
        
    }
    
    public DbSet<UserEntity> User { get; set; }
    public DbSet<SpaceEntity> Space { get; set; }
    public DbSet<AnnotationEntity> Annotation { get; set; }
    public DbSet<QuestionEntity> Question { get; set; }
    public DbSet<ToDoEntity> ToDo { get; set; }
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
        new SpaceConfiguration(modelBuilder.Entity<SpaceEntity>());
        new Annotationconfiguration(modelBuilder.Entity<AnnotationEntity>());
        new QuestionConfiguration(modelBuilder.Entity<QuestionEntity>());
        new ToDoConfiguration(modelBuilder.Entity<ToDoEntity>());
        new NoteConfiguration(modelBuilder.Entity<NoteEntity>());
    }
}