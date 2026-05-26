using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Data
{
    public class BookSoftDbContext : DbContext
    {
        public DbSet<Practitioner> Practitioners { get; set; } //opretter kolonner i db
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Clinic> Clinics { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BookSoftDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        //have not added transaction here because it is not needed for the many to many relationship between practitioner and appointment, and patient and appointment. It is only needed for the one to many relationship between patient and transaction, but that is not the focus of this project, so I have left it out for now.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(BookSoftDbContext).Assembly);

            modelBuilder.Entity<Practitioner>()
                .HasMany(e => e.Appointments)
                .WithOne(e => e.Practitioner);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointments)
                .WithOne(e => e.Patient);

            modelBuilder.Entity<Clinic>()
                .HasMany(e => e.Practitioners)
                .WithMany(e => e.Clinics);

            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.Transactions);
        }
    }
}
