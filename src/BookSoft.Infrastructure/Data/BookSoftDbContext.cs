using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Data
{
    public class BookSoftDbContext : DbContext
    {
        public BookSoftDbContext(DbContextOptions<BookSoftDbContext> options) : base(options) { }

        public DbSet<Practitioner> Practitioners => Set<Practitioner>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Clinic> Clinics => Set<Clinic>();
        public DbSet<Campaign> Campaigns => Set<Campaign>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // henter alle IEntityTypeConfiguration klasser fra dette assembly automatisk
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookSoftDbContext).Assembly);

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

            // mange til mange mellem klinik og behandler
            modelBuilder.Entity<Clinic>()
                .HasMany(e => e.Practitioners)
                .WithMany(e => e.Clinics);

            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.Patient)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.PatientId);

            modelBuilder.Entity<Campaign>()
                .HasMany(e => e.Transactions)
                .WithOne(e => e.Campaign);
        }
    }
}
