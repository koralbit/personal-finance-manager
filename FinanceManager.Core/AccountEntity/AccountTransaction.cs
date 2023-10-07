using FinanceManager.Core.SeedWork;
using FinanceManager.Core.Shared;

public class AccountTransaction : Entity
{
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public TransactionType Type { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime Updated { get; private set; }
    public int GetTransactionCategoryId => _transactionCategoryId;

    private readonly int _transactionCategoryId;



    public AccountTransaction(
        string description,
        decimal amount,
        TransactionType type,
        int transactionCategoryId,
        DateTime date)
    {
        Description = description;
        Amount = amount;
        Type = type;
        _transactionCategoryId = transactionCategoryId;
        Date = date;
    }

}