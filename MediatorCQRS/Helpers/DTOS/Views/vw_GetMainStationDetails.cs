namespace MediatorCQRS.Helpers.DTOS.Views
{
    public class vw_GetMainStationDetails
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string StationCode { get; set; }
        public string StationERPCode { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public int RegionId { get; set; }
        public string Region { get; set; }
        public string District { get; set; }

    }
}
