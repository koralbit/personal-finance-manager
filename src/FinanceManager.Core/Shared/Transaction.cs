using FinanceManager.Core.SeedWork;

namespace FinanceManager.Core.Shared;

public class Transaction : Entity
{
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public TransactionType Type { get; private set; }
    public int TransactionCategoryId { get; private set; }
    public int AccountId { get; private set; }
    public DateTimeOffset Created { get; }
    public DateTimeOffset Updated { get; }

    public Account Account { get; private set; } = null!;

    public Transaction(string description, decimal amount, TransactionType type, int transactionCategoryId, DateTimeOffset date)
    {
        Description = description;
        Amount = amount;
        Type = type;
        TransactionCategoryId = transactionCategoryId;
        Date = date;
    }
}
