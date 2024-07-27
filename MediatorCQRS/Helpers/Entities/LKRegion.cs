namespace MediatorCQRS.Helpers.Entities;

public class LKRegion : BaseEntity<int>, IActiveEntity
{
    public string ArName { get; set; }
    public string EnName { get; set; }

    public ICollection<Station> Station { get; set; }
    public ICollection<LKCity> Cities { get; set; } // Navigation property
}
