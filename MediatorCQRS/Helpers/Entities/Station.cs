namespace MediatorCQRS.Helpers.Entities;

public class Station : BaseEntity<int>, IActiveEntity
{
    public string Name { get; set; }
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public int CityId { get; set; }
    public int RegionId { get; set; }
    public string District { get; set; }
    public string Code { get; set; }
    public string ERPCode { get; set; }
    public LKCity LKCity { get; set; }
    public LKRegion LKRegion { get; set; }
    public ICollection<Tank> Tanks { get; set; }
    public ICollection<Pump> Pumps { get; set; }
    public List<StationProduct> StationProducts { get; set; }
    public ICollection<PointOfSale> PointOfSales { get; set; }
    public ICollection<Order> Orders { get; set; }
}
