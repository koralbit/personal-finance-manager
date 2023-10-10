using FinanceManager.Core.SeedWork;

namespace FinanceManager.Core.Shared;

public abstract class Account : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AccountType AccountType { get; private set; }
    public decimal Balance { get; private set; }
    public DateTimeOffset Created { get; private set; }
    public DateTimeOffset Updated { get; private set; }
    public string UserId { get; private set; }
    public int FinanceEntityId { get; private set; }

    protected readonly List<Transaction> _transactions = new();
    public IReadOnlyCollection<Transaction> Transactions => _transactions;

    public Account(string name, string description, AccountType accountType, int financeEntityId, string userId, decimal balance = 0.0m)
    {
        Name = name;
        Description = description;
        AccountType = accountType;
        FinanceEntityId = financeEntityId;
        UserId = userId;
        Balance = balance;
    }
    protected void SetBalance(decimal amount)
    {
        Balance = amount;
    }

    protected void UpdateBalance()
    {
        var income = Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
        var expense = Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);
        Balance = income - expense;
    }
    
    public void AddTransaction(string description, decimal amount, TransactionType transactionType, int categoryID, DateTimeOffset? date)
    {
        if (date == null)
        {
            date = DateTimeOffset.UtcNow;
            date = DateTimeOffset.Now;
            date = DateTimeOffset.UtcNow.ToLocalTime();
        }
        Transaction transaction = new(description, amount, transactionType,categoryID, date.Value);
        _transactions.Add(transaction);
        UpdateBalance();
    }
}
