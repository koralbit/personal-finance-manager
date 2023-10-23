using FinanceManager.Core.CheckingAccountEntity;
using FinanceManager.Core.CreditCardEntity;
using FinanceManager.Core.Shared;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinanceManager.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<CreditCardAccount> CreditCards { get; set; }
    public DbSet<CheckingAccount> CheckingAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Account>().UseTpcMappingStrategy();


        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}

