namespace MediatorCQRS.Helpers.Entities;

public class LKOrderType : BaseEntity<int>, IActiveEntity
{
    public string Name { get; set; }
    public int SequentialOrder { get; set; }
    public ICollection<Order> Orders { get; set; }
}
