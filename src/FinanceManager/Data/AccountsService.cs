using FinanceManager.Core.CheckingAccountEntity;
using FinanceManager.Core.CreditCardEntity;
using FinanceManager.Core.Shared;
using FinanceManager.Infrastructure.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Data;

public class AccountsService
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;

    public AccountsService(IDbContextFactory<ApplicationDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Account>> GetAccountsAsync()
    {
        using var context = _factory.CreateDbContext();
        var result = await context.Accounts.Where(a => a.UserId == "test").ToListAsync();
        return result;
    }
    public async Task<List<CreditCardAccount>> GetCreditCardsAsync()
    {
        using var context = _factory.CreateDbContext();
        var result = await context.CreditCards.Where(a => a.UserId == "test").ToListAsync();
        return result;
    }

    public async Task<CreditCardAccount?> GetCreditCard(int id)
    {
        using var context = _factory.CreateDbContext();
        var result = await context.CreditCards.Where(a => a.Id == id && a.UserId == "test").Include(nameof(Account.Transactions)).FirstOrDefaultAsync();
        return result;
    }

    public async Task<CreditCardAccount> GenerateCreditCardAsync()
    {
        using var context = _factory.CreateDbContext();
        CreditCardAccount creditCard = new("test", "test", 1000.00m, 1, 1, 1, "test");
        CheckingAccount checkingAccount = new("test", "test", 1, "test");
        creditCard.AddTransaction("test", 100.00m, TransactionType.Expense, 1, null);
        checkingAccount.AddTransaction("test", 100.00m, TransactionType.Expense, 1, null);
        context.CreditCards.Add(creditCard);
        context.CheckingAccounts.Add(checkingAccount);
        await context.SaveChangesAsync();
        return creditCard;
    }
}
