namespace FinanceManager.Core;

public class BaseTransaction
{
    public int TransactionID { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string UserID { get; set; }

    public int CategoryID { get; set; }
    public TransactionCategory Category { get; set; } = null!;


    public BaseTransaction(string description, decimal amount, TransactionType type, string userID, int categoryID, DateTime date)
    {
        Description = description;
        Amount = amount;
        Type = type;
        UserID = userID;
        CategoryID = categoryID;
        Date = date;
    }
}
