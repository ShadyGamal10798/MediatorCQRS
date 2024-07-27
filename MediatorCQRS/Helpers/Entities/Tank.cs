namespace MediatorCQRS.Helpers.Entities;

public class Tank : BaseEntity<int>, IActiveEntity
{
    public string Code { get; set; }
    public decimal Capacity { get; set; }
    public int StationId { get; set; }
    public int LKProductId { get; set; }
    public Station Station { get; set; }
    public LKProduct LKProduct { get; set; }
    public ICollection<Pump> Pumps { get; set; }

    public void SetActiveStatus(bool isActive)
    {
        IsActive = isActive;
        ModifiedDate = DateTime.Now;
    }
}
