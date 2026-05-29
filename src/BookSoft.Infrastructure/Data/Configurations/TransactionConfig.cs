using BookSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSoft.Infrastructure.Data.Configurations;

public class TransactionConfig : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.ID);

        builder.Property(t => t.Beloeb)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        // cost er bare en alias property der peger på Beloeb - skal ikke gemmes i db
        builder.Ignore(t => t.cost);
    }
}
