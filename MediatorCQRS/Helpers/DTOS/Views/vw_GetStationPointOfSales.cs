namespace MediatorCQRS.Helpers.DTOS.Views
{
    public class vw_GetStationPointOfSales
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string Ip { get; set; }
        public string AndroidId { get; set; }
        public int LKPointOfSaleId { get; set; }
        public string PointOfSaleName { get; set; }
    }
}
