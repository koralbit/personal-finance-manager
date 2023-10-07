namespace FinanceManager.Core.Shared;

public class FinanceEntity
{
    public int FinanceEntityId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string IconUrl { get; set; } = null!;


    public FinanceEntity()
    {

    }
}
