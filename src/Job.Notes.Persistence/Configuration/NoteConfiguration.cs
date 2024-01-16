using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public class NoteConfiguration
{
    public NoteConfiguration(EntityTypeBuilder<NoteEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Title).IsRequired();
        entityBuilder.Property(x => x.Content);
        entityBuilder.Property(x => x.Enabled);
        entityBuilder.Property(x => x.Deleted);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);

        entityBuilder
            .HasOne<AnnotationEntity>(x => x.Annotation)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.AnnotationId);
    }
}