namespace MediatorCQRS.Helpers.DTOS.Functions
{
    public class ActiveStationDashboardRequest
    {
        public int? stationId { get; set; }
        public int? cityId { get; set; }
        public int? regionId { get; set; }
        public string? districtName { get; set; }
    }
}
