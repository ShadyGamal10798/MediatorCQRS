namespace MediatorCQRS.Helpers.Entities;

public class Escape : BaseEntity<int>, IActiveEntity
{
    public string? PlateNumber { get; set; }
    public string? Model { get; set; }
    public string? Color { get; set; }
    public string? ImagePath { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}
