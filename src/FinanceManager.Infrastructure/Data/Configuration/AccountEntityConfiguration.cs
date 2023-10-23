using FinanceManager.Core.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Data.Configuration;
public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> config)
    {
        config.HasKey(c => c.Id);

        config.Ignore(c => c.DomainEvents);

        config.Property(c => c.Id)
            .UseHiLo("accountseq");

        config.HasOne<FinanceEntity>()
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        config.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        config.Property(c => c.Description)
            .HasMaxLength(100);

        config.Property(c => c.Balance)
            .HasColumnType("decimal(18,4)");

        config.Property(c => c.Created).HasDefaultValueSql("GETDATE()").IsRequired();
        config.Property(c => c.Updated).HasDefaultValueSql("GETDATE()").IsRequired();

        config.Property(c => c.UserId).HasMaxLength(200).IsRequired();

        var navigation = config.Metadata.FindNavigation(nameof(Account.Transactions));

        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

    }
}
