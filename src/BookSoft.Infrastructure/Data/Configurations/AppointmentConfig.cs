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

        // one patient → many appointments
        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        // one practitioner → many appointments
        builder.HasOne(a => a.Practitioner)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PractitionerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
