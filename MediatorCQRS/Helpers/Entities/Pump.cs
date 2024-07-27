namespace MediatorCQRS.Helpers.Entities;

public class Pump : BaseEntity<int>, IActiveEntity
{
    public int StationId { get; set; }
    public string Code { get; set; }
    public string ERPCode { get; set; }
    public int TankId { get; set; }
    public Station Station { get; set; }
    public Tank Tank { get; set; }
    public void SetActiveStatus(bool isActive)
    {
        IsActive = isActive;
        ModifiedDate = DateTime.Now;
    }
}
