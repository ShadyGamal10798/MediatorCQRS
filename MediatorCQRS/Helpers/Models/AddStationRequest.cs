using System.IO;

namespace MediatorCQRS.Helpers.Models
{
    public class AddStationRequest
    {
        public string StationName { get; set; }
        public string StationCode { get; set; }
        public string StationERPCode { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public string District { get; set; }
        public List<PriceInfo> PricesInfo { get; set; }
        public List<TankInfo> TanksInfo { get; set; }
        public List<PumpInfo> PumpsInfo { get; set; }
        public List<PosInfo> PosInfo { get; set; }

        public AddStationRequest(
        string stationName,
        string stationCode,
        string stationERPCode,
        int cityId,
        int regionId,
        string district,
        List<PriceInfo> pricesInfo,
        List<TankInfo> tanksInfo,
        List<PumpInfo> pumpsInfo,
        List<PosInfo> posInfo)
        {
            StationName = stationName;
            StationCode = stationCode;
            StationERPCode = stationERPCode;
            CityId = cityId;
            RegionId = regionId;
            District = district;
            PricesInfo = pricesInfo;
            TanksInfo = tanksInfo;
            PumpsInfo = pumpsInfo;
            PosInfo = posInfo;
        }
    }

}
