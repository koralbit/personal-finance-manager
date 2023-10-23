using FinanceManager.Core.CreditCardEntity;
using FinanceManager.Core.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Data.Configuration;
public class TransactionEntityConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> config)
    {
        config.ToTable("Transactions");

        config.HasKey(c => c.Id);

        config.Property(c => c.Id)
            .UseHiLo("transactionseq");

        config.Ignore(c => c.DomainEvents);

        config.Property(c => c.Description)
            .HasMaxLength(100).IsRequired();

        config.Property(c => c.Type)
            .IsRequired();

        config.Property(c => c.Date)
            .IsRequired();

        config.Property(c => c.Created).HasDefaultValueSql("GETUTCDATE()").IsRequired();
        config.Property(c => c.Updated).HasDefaultValueSql("GETUTCDATE()").IsRequired();

        config.Property(c => c.Amount)
            .HasColumnType("decimal(18,4)");

        config.HasOne<TransactionCategory>()
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
