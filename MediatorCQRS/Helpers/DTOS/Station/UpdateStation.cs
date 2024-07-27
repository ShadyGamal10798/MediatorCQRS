using MediatorCQRS.Helpers.DTOS;

namespace MediatorCQRS.Helpers.DTOS.Station
{
    public record UpdateStation
    (
        int StationId,
        string StationName,
        string StationCode,
        string StationERPCode,
        int CityId,
        int RegionId,
        string District,
        List<PriceInfo>? PricesInfo
    );
}
