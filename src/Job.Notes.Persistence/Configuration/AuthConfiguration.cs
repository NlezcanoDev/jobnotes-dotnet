using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public static class AuthConfiguration
{
    public static void Configure(EntityTypeBuilder<AuthEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.UserId);
        entityBuilder.Property(x => x.Salt).IsRequired();
        entityBuilder.Property(x => x.Hash).IsRequired();
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.ExpirationDate);
        entityBuilder.Property(x => x.Enabled).HasColumnType("bit").HasDefaultValue(true);
        
        entityBuilder.HasOne<UserEntity>(x => x.User)
            .WithOne()
            .HasForeignKey<AuthEntity>(s => s.UserId);
    }
}