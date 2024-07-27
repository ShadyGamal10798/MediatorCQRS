
namespace MediatorCQRS.Helpers.DTOS.Views
{
    public class vw_GetStationPrices
    {
        public int StationId { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
    }
}
