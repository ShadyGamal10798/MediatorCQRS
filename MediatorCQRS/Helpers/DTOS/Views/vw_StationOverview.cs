namespace MediatorCQRS.Helpers.DTOS.Views
{
    public class vw_StationOverview
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public string StationCode { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string District { get; set; }
        public int UserCount { get; set; }
        public int TankCount { get; set; }
        public int PumpCount { get; set; }
        public int PosCount { get; set; }
    }
}
