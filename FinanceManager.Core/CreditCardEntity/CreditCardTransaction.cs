using FinanceManager.Core.Shared;

namespace FinanceManager.Core.CreditCardEntity;

public class CreditCardTransaction : BaseTransaction
{
    public CreditCardTransaction(
        string description,
        decimal amount,
        TransactionType type,
        int transactionCategoryId,
        DateTimeOffset date)
        : base(description, amount, type, transactionCategoryId, date)
    {
    }
}
