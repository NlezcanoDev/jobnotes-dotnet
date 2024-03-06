using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Job.Notes.Persistence.Configuration;

public static class NoteConfiguration
{
    public static void Configure(EntityTypeBuilder<NoteEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Title).IsRequired();
        entityBuilder.Property(x => x.Content);
        entityBuilder.Property(x => x.Enabled).HasColumnType("bit").HasDefaultValue(true);
        entityBuilder.Property(x => x.Deleted).HasColumnType("bit").HasDefaultValue(false);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);

        entityBuilder
            .HasOne<SpaceEntity>(x => x.Space)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.SpaceId);
    }
}