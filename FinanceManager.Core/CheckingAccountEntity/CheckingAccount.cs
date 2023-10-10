using FinanceManager.Core.Shared;

namespace FinanceManager.Core.CheckingAccountEntity;
public class CheckingAccount : Account
{
    public CheckingAccount(string name, string description, int financeEntityId, string userId, decimal balance = 0.0m)
        : base(name, description, AccountType.CreditCard, financeEntityId, userId, balance)
    {
    }
}