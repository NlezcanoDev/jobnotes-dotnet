using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public class ToDoConfiguration
{
    public ToDoConfiguration(EntityTypeBuilder<ToDoEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Title).IsRequired();
        entityBuilder.Property(x => x.Description);
        entityBuilder.Property(x => x.Done);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);

        entityBuilder
            .HasOne<AnnotationEntity>(x => x.Annotation)
            .WithMany(x => x.ToDos)
            .HasForeignKey(x => x.AnnotationId);
    }
}