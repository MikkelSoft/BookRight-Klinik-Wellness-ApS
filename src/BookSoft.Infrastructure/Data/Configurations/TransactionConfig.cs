using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSoft.Infrastructure.Data.Configurations;

public class TransactionConfig : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.ID);

        builder.Property(t => t.cost)
            .HasColumnType("decimal(18,2)");

        // one patient → many transactions
        builder.HasOne(t => t.Patient)
            .WithMany(p => p.Transactions)
            .HasForeignKey(t => t.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}