using FinanceManager.Core.CreditCardEntity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinanceManager.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<CreditCardTransaction> CreditCardTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}

