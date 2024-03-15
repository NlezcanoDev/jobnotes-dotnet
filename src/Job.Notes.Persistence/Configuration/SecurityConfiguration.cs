using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public static class SecurityConfiguration
{
    public static void Configure(EntityTypeBuilder<SecurityEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.UserId);
        entityBuilder.Property(x => x.Password).IsRequired();
        entityBuilder.Property(x => x.SuccessLoginDate).HasDefaultValue(null);
        entityBuilder.Property(x => x.FailedAttempts).HasDefaultValue(0);
        entityBuilder.Property(x => x.FailedAttemptDate);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);

        entityBuilder.HasOne<UserEntity>(x => x.User)
            .WithOne()
            .HasForeignKey<SecurityEntity>(s => s.UserId);
    }
}