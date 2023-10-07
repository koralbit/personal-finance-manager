using FinanceManager.Core.SeedWork;

namespace FinanceManager.Core.Shared;

public class BaseTransaction : Entity
{
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public TransactionType Type { get; private set; }
    public int TransactionCategoryId { get; private set; }
    public DateTimeOffset Created { get; }
    public DateTimeOffset Updated { get; }

    public BaseTransaction(string description, decimal amount, TransactionType type, int transactionCategoryId, DateTimeOffset date)
    {
        Description = description;
        Amount = amount;
        Type = type;
        TransactionCategoryId = transactionCategoryId;
        Date = date;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetAmount(decimal amount)
    {
        Amount = amount;
    }

    public void SetDate(DateTimeOffset date)
    {
        Date = date;
    }
    public void SetType(TransactionType type)
    {
        Type = type;
    }

    public void SetTransactionCategoryId(int transactionCategoryId)
    {
        TransactionCategoryId = transactionCategoryId;
    }

}
