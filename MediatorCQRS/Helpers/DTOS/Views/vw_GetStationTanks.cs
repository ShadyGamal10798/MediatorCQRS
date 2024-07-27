namespace MediatorCQRS.Helpers.DTOS.Views
{
    public class vw_GetStationTanks
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string TankCode { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public decimal Capacity { get; set; }
    }
}
