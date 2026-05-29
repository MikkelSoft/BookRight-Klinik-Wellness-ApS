using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//det kan godt være at det giver mening at lave en personconfig metode siden at både practitioner og patient nedarver FullName VO fra Person

namespace BookSoft.Infrastructure.Data.Configurations
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.ID);

            builder.OwnsOne(e => e.FullName)/* value object :D, det er også muligt at bruge complexproperty så den laver json fil
                .Property(e => e.FirstName) kan bruge det her hvis kolonen skal hedde noget andet end det den selv opretter (den plejer vist bare at navngive efter variablernes navne i VO
                .HasColumnName("FirstName")*/;

            // TotalSpent — akkumuleret betalingshistorik, gemmes med 2 decimaler
            builder.Property(e => e.TotalSpent)
                .HasColumnType("decimal(18,2)");
        }
    }
}
