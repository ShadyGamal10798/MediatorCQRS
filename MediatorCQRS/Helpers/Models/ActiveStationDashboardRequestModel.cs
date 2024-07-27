namespace MediatorCQRS.Helpers.Models
{
    public class ActiveStationDashboardRequestModel
    {
        public int? stationId { get; set; }
        public int? cityId { get; set; }
        public int? regionId { get; set; }
        public string? districtName { get; set; }
    }
}
