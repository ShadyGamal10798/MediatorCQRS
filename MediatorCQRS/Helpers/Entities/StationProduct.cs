using System.ComponentModel.DataAnnotations.Schema;

namespace MediatorCQRS.Helpers.Entities;

public class StationProduct
{
    [Column(Order = 2)]
    public int? CreatedBy { get; protected set; }
    [Column(Order = 3)]
    public DateTime CreatedDate { get; protected set; } = DateTime.Now;
    [Column(Order = 4)]
    public int? ModifiedBy { get; protected set; }
    [Column(Order = 5)]
    public DateTime? ModifiedDate { get; protected set; }
    [Column(Order = 6)]
    public bool IsActive { get; protected set; } = true;
    public int StationId { get; set; }
    public int LKProductId { get; set; }
    public decimal Price { get; set; }
    public Station Station { get; set; }

    public LKProduct LKProduct { get; set; }

    public void SetActiveStatus(bool isActive)
    {
        IsActive = isActive;
        ModifiedDate = DateTime.Now; // Optionally update the modified date
    }


}
