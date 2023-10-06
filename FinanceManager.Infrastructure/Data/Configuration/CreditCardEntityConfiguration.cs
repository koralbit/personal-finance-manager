using FinanceManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infrastructure.Data.Configuration;
public class CreditCardEntityConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> config)
    {
        config.ToTable("CreditCards");

        config.HasKey(e => e.Id);

        config.Ignore(b => b.DomainEvents);

        config.Property(e => e.Id)
            .UseHiLo("creditcardseq");

        config.HasOne<FinanceEntity>()
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        config.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        config.Property(e => e.Description)
            .HasMaxLength(100);

        config.Property(e => e.CreditLimit)
            .HasColumnType("decimal(18,2)");

        var navigation = config.Metadata.FindNavigation(nameof(CreditCard.Transactions));

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    }
}
