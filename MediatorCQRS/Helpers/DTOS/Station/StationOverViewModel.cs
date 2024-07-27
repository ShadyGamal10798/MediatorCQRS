

using MediatorCQRS.Helpers.DTOS;

namespace MediatorCQRS.Helpers.DTOS.Station
{
    public class StationOverViewModel : PaginationRequest
    {
        public string? Code { get; set; }
        public int? RegionId { get; set; }
        public int? CityId { get; set; }
    }
}
