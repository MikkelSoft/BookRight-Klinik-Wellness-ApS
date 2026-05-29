using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

public class CampaignConfig : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.HasKey(a => a.ID);

        builder.Property(c => c.DiscountProcent)
            .HasColumnType("decimal(5,4)");

        builder.PrimitiveCollection(c => c.ValidFor);
    }
}

