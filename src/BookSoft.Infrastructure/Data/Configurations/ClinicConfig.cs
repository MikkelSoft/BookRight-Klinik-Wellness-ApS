using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSoft.Infrastructure.Data.Configurations;

public class ClinicConfig : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.HasKey(c => c.ID);

        builder.Property(c => c.ClinicName)
            .IsRequired()
            .HasMaxLength(200);
    }
}