using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public static class RegistrationSecurityConfiguration
{
    public static void Configure(EntityTypeBuilder<RegistrationSecurityEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Mail).IsRequired();
        entityBuilder.Property(x => x.Code).IsRequired();
        entityBuilder.Property(x => x.Enabled).HasColumnType("bit").HasDefaultValue(true);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.ExpirationDate);

        entityBuilder.HasOne<UserEntity>(x => x.User)
            .WithMany()
            .HasForeignKey(s => s.UserId);
    }
}