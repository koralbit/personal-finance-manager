using FinanceManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infrastructure.Data.Configuration;
public class CreditCardTransactionEntityConfiguration : IEntityTypeConfiguration<CreditCardTransaction>
{
    public void Configure(EntityTypeBuilder<CreditCardTransaction> config)
    {
        config.ToTable("CreditCardTransactions");

        config.HasKey(e => e.Id);

        config.Ignore(b => b.DomainEvents);

        config.Property(e => e.Id)
            .UseHiLo("creditcardtransactionseq");


        config.HasOne<TransactionCategory>()
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
