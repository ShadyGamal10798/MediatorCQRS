namespace MediatorCQRS.Helpers.Entities;

public class PointOfSale : BaseEntity<int>, IActiveEntity
{
    public string Ip { get; set; }
    public string AndroidId { get; set; }
    public int StationId { get; set; }
    public int LKPointOfSaleId { get; set; } // Foreign key
    public Station Station { get; set; }
    public LKPointOfSale LKPointOfSale { get; set; } // Navigation property
    public ICollection<Order> Orders { get; set; }

    public void SetActiveStatus(bool isActive)
    {
        IsActive = isActive;
        ModifiedDate = DateTime.UtcNow;
    }
}
