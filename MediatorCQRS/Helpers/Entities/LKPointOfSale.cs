namespace MediatorCQRS.Helpers.Entities;

public class LKPointOfSale : BaseEntity<int>, IActiveEntity
{
    public string ArName { get; set; }
    public string EnName { get; set; }

    public ICollection<PointOfSale> PointOfSales { get; set; } // Navigation property
}
