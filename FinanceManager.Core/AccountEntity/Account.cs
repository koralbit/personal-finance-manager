using FinanceManager.Core.SeedWork;

namespace FinanceManager.Core.AccountEntity;
public class Account : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public AccountType AccountType { get; set; }
    public decimal Balance { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string UserId { get; set; }
    public decimal CreditLimit { get; set; }
    public int GetFinanceEntityId => _financeEntityId;

    private readonly int _financeEntityId;

    private readonly List<AccountTransaction> _transactions = new();
    public IReadOnlyCollection<AccountTransaction> Transactions => _transactions;
    public Account(string name, string description, int financeEntityId, string userId)
    {
        Name = name;
        Description = description;
        AccountType = AccountType.CreditCard;
        _financeEntityId = financeEntityId;
        UserId = userId;
    }
}
