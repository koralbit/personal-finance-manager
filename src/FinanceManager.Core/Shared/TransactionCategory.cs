namespace FinanceManager.Core.Shared;

public class TransactionCategory
{
    public int TransactionCategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    public bool IsCommonCategory { get; set; }

    public string UserID { get; set; } = null!;

    public TransactionCategory()
    {

    }

    //public User User { get; set; } = null!;
}
