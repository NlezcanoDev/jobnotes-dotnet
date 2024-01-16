using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public class Annotationconfiguration
{
    public Annotationconfiguration(EntityTypeBuilder<AnnotationEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Title).IsRequired();
        entityBuilder.Property(x => x.Description);
        entityBuilder.Property(x => x.AnnotationType).IsRequired().HasConversion<byte>();
        entityBuilder.Property(x => x.Enabled);
        entityBuilder.Property(x => x.Deleted);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);

        entityBuilder
            .HasOne<SpaceEntity>(x => x.Space)
            .WithMany(x => x.Annotations)
            .HasForeignKey(x => x.SpaceId);
    }
}