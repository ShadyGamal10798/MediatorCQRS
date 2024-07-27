namespace MediatorCQRS.Helpers.Entities;

public class LKProduct : BaseEntity<int>, IActiveEntity
{
    public string ArName { get; set; }
    public string EnName { get; set; }
    public string UrName { get; set; }
    public string BnName { get; set; }
    public string Code { get; set; }
    public string ERPCode { get; set; }
    public decimal Price { get; set; }
    public ICollection<StationProduct> StationProducts { get; set; }
    public ICollection<Tank> Tanks { get; set; }
    public ICollection<MainPriceHistory> MainPriceHistories { get; set; }
    public ICollection<Order> Orders { get; set; }
}
