namespace MediatorCQRS.Helpers.Entities;

public class MainPriceHistory : BaseEntity<int>, IActiveEntity
{
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public int LKProductId { get; set; }
    public LKProduct LKProduct { get; set; }
}
