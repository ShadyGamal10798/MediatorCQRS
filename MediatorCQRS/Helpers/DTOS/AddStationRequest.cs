﻿namespace MediatorCQRS.Helpers.DTOS
{
    //public class AddStationRequest
    //{
    //    public string StationName { get; set; }
    //    public string StationCode { get; set; }
    //    public string StationERPCode { get; set; }
    //    public int CityId { get; set; }
    //    public int RegionId { get; set; }
    //    public string District { get; set; }
    //    public List<PriceInfo> PricesInfo { get; set; }
    //    public List<TankInfo> TanksInfo { get; set; }
    //    public List<PumpInfo> PumpsInfo { get; set; }
    //    public List<PosInfo> PosInfo { get; set; }
    //}

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
