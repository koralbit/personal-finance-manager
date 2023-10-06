namespace FinanceManager.Core;

public class BaseAccount
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AccountType AccountType { get; set; }
    public decimal Balance { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public int FinanceEntityID { get; set; }
    public string UserID { get; set; }

    public FinanceEntity FinanceEntity { get; set; } = null!;

    public BaseAccount(string name, string description, AccountType accountType, int financeEntityID, string userID, decimal balance = 0.0m)
    {
        Name = name;
        Description = description;
        AccountType = accountType;
        FinanceEntityID = financeEntityID;
        UserID = userID;
        Balance = balance;
    }

}
