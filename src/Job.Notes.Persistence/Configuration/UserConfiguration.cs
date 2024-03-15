using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public static class UserConfiguration
{
    public static void Configure(EntityTypeBuilder<UserEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Name).IsRequired();
        entityBuilder.Property(x => x.Lastname).IsRequired();
        entityBuilder.Property(x => x.Username).IsRequired();
        entityBuilder.Property(x => x.Mail).IsRequired();
        entityBuilder.Property(x => x.Role).HasConversion<byte>();
        entityBuilder.Property(x => x.ProfileImg);
        entityBuilder.Property(x => x.Enabled).HasColumnType("bit").HasDefaultValue(false);
        entityBuilder.Property(x => x.Deleted).HasColumnType("bit").HasDefaultValue(false);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);

        entityBuilder.HasIndex(x => x.Username).IsUnique();
        entityBuilder.HasIndex(x => x.Mail).IsUnique();

        entityBuilder.HasAlternateKey(x => x.Mail);
    }
}