using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Data
{
    public class BookSoftDbContext : DbContext
    {
        public DbSet<Practitioner> Practitioners => Set<Practitioner>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Clinic> Clinics => Set<Clinic>();

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

            modelBuilder.Entity<Appointment>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.Appointments)
                .HasForeignKey(e => e.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(e => e.Practitioner)
                .WithMany(e => e.Appointments)
                .HasForeignKey(e => e.PractitionerId);

            modelBuilder.Entity<Appointment>()
                .HasOne(e => e.Clinic)
                .WithMany(e => e.Appointments)
                .HasForeignKey(e => e.ClinicId);

            modelBuilder.Entity<Clinic>()
                .HasMany(e => e.Practitioners)
                .WithMany(e => e.Clinics);

            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.PatientId);
        }
    }
}
