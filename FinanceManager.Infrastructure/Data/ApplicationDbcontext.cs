using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Core;
using Microsoft.EntityFrameworkCore;

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
    
