namespace MediatorCQRS.Helpers.Models
{
    public class StationOverViewModel
    {
        public string? Code { get; set; }
        public int? RegionId { get; set; }
        public int? CityId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
