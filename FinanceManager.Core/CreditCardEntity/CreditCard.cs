using FinanceManager.Core.AccountEntity;
using FinanceManager.Core.Shared;

namespace FinanceManager.Core.CreditCardEntity;
public class CreditCard : BaseAccount
{
    public decimal CreditLimit { get; set; }
    public int StatementDay { get; set; }
    public int PaymentDay { get; set; }

    private readonly List<CreditCardTransaction> _transactions = new();
    public IReadOnlyCollection<CreditCardTransaction> Transactions => _transactions;


    public CreditCard(string name, string description, decimal creditLimit, int statementDay, int paymentDay, int financeEntityId, string userId, decimal balance = 0.0m)
        : base(name, description, AccountType.CreditCard, financeEntityId, userId)
    {
        StatementDay = statementDay;
        PaymentDay = paymentDay;
        CreditLimit = creditLimit;
        SetBalance(balance);
    }

    public void AddTransaction(string description, decimal amount, TransactionType transactionType, int categoryID, DateTimeOffset? date)
    {
        if (date == null)
        {
            date = DateTimeOffset.Now;
        }
        CreditCardTransaction transaction = new(description, amount, transactionType, categoryID, date.Value);
        _transactions.Add(transaction);
        UpdateBalance();
    }

    public void AddPayment(string description, decimal amount, int categoryID, DateTimeOffset? paymentDate)
    {
        if (paymentDate == null)
        {
            paymentDate = DateTimeOffset.Now;
        }
        CreditCardTransaction transaction = new(description, amount, TransactionType.Income, categoryID, paymentDate.Value);
        _transactions.Add(transaction);
        UpdateBalance();
    }

    public void AddCharge(string description, decimal amount, int categoryID, DateTimeOffset? chargeDate)
    {
        if (chargeDate == null)
        {
            chargeDate = DateTimeOffset.Now;
        }
        CreditCardTransaction transaction = new(description, amount, TransactionType.Expense, categoryID, chargeDate.Value);
        _transactions.Add(transaction);
        UpdateBalance();
    }

    public void RemoveTransaction(int transactionId)
    {
        _transactions.RemoveAll(t => t.Id == transactionId);
    }

    public void UpdateTransaction(int transactionId, string description, decimal amount, TransactionType transactionType, int categoryId, DateTimeOffset date)
    {
        CreditCardTransaction transaction = _transactions.FirstOrDefault(t => t.Id == transactionId)!;
        if (transaction is null) return;
        transaction.SetType(transactionType);
        transaction.SetDescription(description);
        transaction.SetDate(date);
        transaction.SetAmount(amount);
        transaction.SetTransactionCategoryId(categoryId);
        UpdateBalance();
    }

    public decimal GetUpcomingBalance()
    {
        decimal balance = Balance;
        foreach (var transaction in _transactions)
        {
            if (transaction.Type == TransactionType.Expense)
            {
                balance -= transaction.Amount;
            }
            else
            {
                balance += transaction.Amount;
            }
        }
        return balance;

    }

    private void UpdateBalance()
    {
        decimal balance = Balance;
        foreach (var transaction in _transactions)
        {
            // Skip transactions that are in the future
            if (transaction.Date >= DateTimeOffset.Now) continue;

            if (transaction.Type == TransactionType.Expense)
            {
                balance -= transaction.Amount;
            }
            else
            {
                balance += transaction.Amount;
            }
        }
        SetBalance(balance);
    }
}
