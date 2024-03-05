using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public class UserConfiguration
{
    public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Name).IsRequired();
        entityBuilder.Property(x => x.LastName).IsRequired();
        entityBuilder.Property(x => x.UserName).IsRequired();
        entityBuilder.Property(x => x.Mail).IsRequired();
        entityBuilder.Property(x => x.Password).IsRequired();
        entityBuilder.Property(x => x.Role).HasConversion<byte>();
        entityBuilder.Property(x => x.ProfileImg);
        entityBuilder.Property(x => x.Enabled).HasColumnType("bit").HasDefaultValue(true);
        entityBuilder.Property(x => x.Deleted).HasColumnType("bit").HasDefaultValue(false);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);

        entityBuilder.HasIndex(x => x.UserName).IsUnique();
        entityBuilder.HasIndex(x => x.Mail).IsUnique();
    }
}