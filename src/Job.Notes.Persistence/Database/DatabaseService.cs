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

    // Users
    public DbSet<UserEntity> User { get; set; }
    
    // Application
    public DbSet<ProjectEntity> Project { get; set; }
    public DbSet<SpaceEntity> Space { get; set; }
    public DbSet<QuestionListEntity> QuestionList { get; set; }
    public DbSet<QuestionEntity> Question { get; set; }
    public DbSet<TaskListEntity> TaskList { get; set; }
    public DbSet<TaskEntity> Task { get; set; }
    public DbSet<NoteEntity> Note { get; set; }
    
    // Security
    public DbSet<RegistrationSecurityEntity> RegistrationSecurity { get; set; }
    public DbSet<SecurityEntity> Security { get; set; }
    public DbSet<AuthEntity> Auth { get; set; }

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
        // Users
        UserConfiguration.Configure(modelBuilder.Entity<UserEntity>());
        
        // Application
        ProjectConfiguration.Configure(modelBuilder.Entity<ProjectEntity>());
        SpaceConfiguration.Configure(modelBuilder.Entity<SpaceEntity>());
        QuestionListConfiguration.Configure(modelBuilder.Entity<QuestionListEntity>());
        QuestionConfiguration.Configure(modelBuilder.Entity<QuestionEntity>());
        TaskListConfiguration.Configure(modelBuilder.Entity<TaskListEntity>());
        TaskConfiguration.Configure(modelBuilder.Entity<TaskEntity>());
        NoteConfiguration.Configure(modelBuilder.Entity<NoteEntity>());
        
        // Security
        SecurityConfiguration.Configure(modelBuilder.Entity<SecurityEntity>());
        RegistrationSecurityConfiguration.Configure(modelBuilder.Entity<RegistrationSecurityEntity>());
        AuthConfiguration.Configure(modelBuilder.Entity<AuthEntity>());
    }
}