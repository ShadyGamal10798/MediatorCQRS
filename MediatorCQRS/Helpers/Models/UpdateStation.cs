using System.IO;

namespace MediatorCQRS.Helpers.Models
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
    public class PriceInfo
    {
        public int LKProductId { get; set; }
        public decimal Price { get; set; }
    }
    public class TankInfo
    {
        public string Code { get; set; }
        public decimal Capacity { get; set; }
        public int LKProductId { get; set; }
    }

    public class PumpInfo
    {
        public string Code { get; set; }
        public string ERPCode { get; set; }
        public string TankCode { get; set; }
    }
    public class PosInfo
    {
        public string PosId { get; set; }
        public int LKPointOfSaleId { get; set; }
        public string AndroidId { get; set; }
    }




}
