using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Core;
public class CreditCard : Entity
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
    public DateTime StatementDate { get; set; }
    public DateTime PaymentDate { get; set; }
    
    private readonly List<CreditCardTransaction> _transactions;
    public IReadOnlyCollection<CreditCardTransaction> Transactions => _transactions;


    public CreditCard(string name, string description, int financeEntityId, string userId)
    {
        Name = name;
        Description = description;
        AccountType = AccountType.CreditCard;
        _financeEntityId = financeEntityId;
        UserId = userId;
        Created = DateTime.Now;
        Updated = DateTime.Now;
        _transactions = new List<CreditCardTransaction>();
    }

    public void AddTransaction(string description, decimal amount, TransactionType transactionType, int categoryID, DateTime? date)
    {
        if (date == null)
        {
            date = DateTime.Now;
        }
        CreditCardTransaction transaction = new(description, amount, transactionType, categoryID, date.Value);
    }

    public void AddPayment(string description, decimal amount, int categoryID, int accountID, DateTime? paymentDate)
    {
        if (paymentDate == null)
        {
            paymentDate = DateTime.Now;
        }
        CreditCardTransaction transaction = new(description, amount, TransactionType.Income, categoryID, paymentDate.Value);
        _transactions.Add(transaction);
    }

    public void AddCharge(string description, decimal amount, int categoryID, DateTime? chargeDate)
    {
        if (chargeDate == null)
        {
            chargeDate = DateTime.Now;
        }
        CreditCardTransaction transaction = new(description, amount, TransactionType.Expense, categoryID, chargeDate.Value);
        _transactions.Add(transaction);
    }
}
