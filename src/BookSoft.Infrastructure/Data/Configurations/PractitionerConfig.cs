using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSoft.Infrastructure.Data.Configurations
{
    public class PractitionerConfig : IEntityTypeConfiguration<Practitioner>
    {
        public void Configure(EntityTypeBuilder<Practitioner> builder)
        {
            builder.HasKey(e => e.ID);

            builder.OwnsOne(e => e.FullName)/*
                .Property(e => e.FirstName)
                .HasColumnName("FirstName")*/;
        }
    }
}
