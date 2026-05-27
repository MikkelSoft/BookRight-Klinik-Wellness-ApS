using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSoft.Infrastructure.Data.Configurations;

public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.ID);

        builder.Property(a => a.AppointmentTypeString)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.Pris)
            .HasColumnType("decimal(18,2)");
    }
}
