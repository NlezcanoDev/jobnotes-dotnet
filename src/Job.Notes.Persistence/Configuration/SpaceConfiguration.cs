﻿using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public class SpaceConfiguration
{
    public SpaceConfiguration(EntityTypeBuilder<SpaceEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Name).IsRequired();
        entityBuilder.Property(x => x.Description);
        entityBuilder.Property(x => x.Status).HasConversion<byte>();
        entityBuilder.Property(x => x.Enabled).HasColumnType("bit").HasDefaultValue(true);
        entityBuilder.Property(x => x.Deleted).HasColumnType("bit").HasDefaultValue(false);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);
    }
}