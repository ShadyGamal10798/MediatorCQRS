namespace MediatorCQRS.Helpers.Entities;

public class Customer : BaseEntity<int>, IActiveEntity
{
    public string FullName { get; set; }
    public decimal Balance { get; set; }
    public string IdNumber { get; set; }
    public ICollection<Order> Orders { get; set; }
}
