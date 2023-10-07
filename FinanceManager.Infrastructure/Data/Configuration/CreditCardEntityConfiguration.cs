using FinanceManager.Core.CreditCardEntity;
using FinanceManager.Core.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Data.Configuration;
public class CreditCardEntityConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> config)
    {
        config.ToTable("CreditCards");

        config.HasKey(c => c.Id);

        config.Ignore(c => c.DomainEvents);

        config.Property(c => c.Id)
            .UseHiLo("creditcardseq");

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
            .HasColumnType("decimal(18,2)");

        config.Property(c => c.CreditLimit)
            .HasColumnType("decimal(18,2)");

        config.Property(c => c.Created).HasDefaultValueSql("GETUTCDATE()").IsRequired();
        config.Property(c => c.Updated).HasDefaultValueSql("GETUTCDATE()").IsRequired();

        config.Property(c => c.UserId).HasMaxLength(200).IsRequired();

        var navigation = config.Metadata.FindNavigation(nameof(CreditCard.Transactions));

        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

    }
}
