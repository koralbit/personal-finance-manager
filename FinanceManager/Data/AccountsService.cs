using FinanceManager.Core.CreditCardEntity;
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
    

    public async Task<List<CreditCard>> GetCreditCardsAsync()
    {
        try
        {
            using var context = _factory.CreateDbContext();
            var result = await context.CreditCards.ToListAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }

}
