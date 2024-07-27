namespace MediatorCQRS.Helpers.Entities;

public class LKCity : BaseEntity<int>, IActiveEntity
{
    public string ArName { get; set; }
    public string EnName { get; set; }
    public int LKRegionId { get; set; }

    public LKRegion Region { get; set; }
    public ICollection<Station> Station { get; set; }
}
