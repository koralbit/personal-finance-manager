using FinanceManager.Core.AccountEntity;
using FinanceManager.Core.SeedWork;

namespace FinanceManager.Core.Shared;

public class BaseAccount : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AccountType AccountType { get; private set; }
    public decimal Balance { get; private set; } = 0.0m;
    public DateTimeOffset Created { get; private set; }
    public DateTimeOffset Updated { get; private set; }
    public string UserId { get; private set; }
    public int FinanceEntityId { get; private set; }


    public BaseAccount(string name, string description, AccountType accountType, int financeEntityId, string userId)
    {
        Name = name;
        Description = description;
        AccountType = accountType;
        FinanceEntityId = financeEntityId;
        UserId = userId;
    }

    public void SetBalance(decimal amount)
    {
        Balance = amount;
    }

}
