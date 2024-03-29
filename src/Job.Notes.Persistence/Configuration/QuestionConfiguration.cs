﻿using Job.Notes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Job.Notes.Persistence.Configuration;

public class QuestionConfiguration
{
    public QuestionConfiguration(EntityTypeBuilder<QuestionEntity> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.Question).IsRequired();
        entityBuilder.Property(x => x.Answer);
        entityBuilder.Property(x => x.AdditionalNote);
        entityBuilder.Property(x => x.Enabled).HasColumnType("bit").HasDefaultValue(true);
        entityBuilder.Property(x => x.Deleted).HasColumnType("bit").HasDefaultValue(false);
        entityBuilder.Property(x => x.CreateDate);
        entityBuilder.Property(x => x.UpdateDate);
        entityBuilder.Property(x => x.CreatedBy).IsRequired();
        entityBuilder.Property(x => x.UpdatedBy);

        entityBuilder
            .HasOne<AnnotationEntity>(x => x.Annotation)
            .WithMany(x => x.Questions)
            .HasForeignKey(x => x.AnnotationId);
    }
}