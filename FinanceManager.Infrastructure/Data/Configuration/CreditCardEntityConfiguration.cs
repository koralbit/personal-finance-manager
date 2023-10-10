using FinanceManager.Core.CreditCardEntity;
using FinanceManager.Core.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Data.Configuration;
public class CreditCardEntityConfiguration : IEntityTypeConfiguration<CreditCardAccount>
{
    public void Configure(EntityTypeBuilder<CreditCardAccount> config)
    {
        config.Property(c => c.Id)
            .UseHiLo("accountseq");
        config.Property(c => c.CreditLimit)
            .HasPrecision(18, 4);

        config.Property(c => c.PaymentDay)
            .IsRequired();
        
        config.Property(c => c.StatementDay)
            .IsRequired();
    }
}
