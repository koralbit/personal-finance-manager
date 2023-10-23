using FinanceManager.Core.Shared;

namespace FinanceManager.Core.CreditCardEntity;
public class CreditCardAccount : Account
{
    public decimal CreditLimit { get; set; }
    public int StatementDay { get; set; }
    public int PaymentDay { get; set; }

    public CreditCardAccount(string name, string description, decimal creditLimit, int statementDay, int paymentDay, int financeEntityId, string userId, decimal balance = 0.0m)
        : base(name, description, AccountType.CreditCard, financeEntityId, userId, balance)
    {
        StatementDay = statementDay;
        PaymentDay = paymentDay;
        CreditLimit = creditLimit;
    }
}
