using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public static class TaskConfiguration
{
    public static void Configure(EntityTypeBuilder<TaskEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Title).IsRequired();
        entityBuilder.Property(x => x.Description);
        entityBuilder.Property(x => x.Done).HasColumnType("bit").HasDefaultValue(false);
        entityBuilder.Property(x => x.Enabled).HasColumnType("bit").HasDefaultValue(true);
        entityBuilder.Property(x => x.Deleted).HasColumnType("bit").HasDefaultValue(false);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);

        entityBuilder
            .HasOne<TaskListEntity>(x => x.TaskList)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.TaskListId);
    }
}