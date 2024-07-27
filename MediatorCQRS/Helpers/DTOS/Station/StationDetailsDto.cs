using MediatorCQRS.Helpers.DTOS.Views;

namespace MediatorCQRS.Helpers.DTOS.Station
{
    public class StationDetailsDto
    {
        public vw_GetMainStationDetails? MainStationDetails { get; set; }
        public List<vw_GetStationPrices>? StationPrices { get; set; }
        public List<vw_GetStationTanks>? StationTanks { get; set; }
        public List<vw_GetStationPumps>? StationPumps { get; set; }
        public List<vw_GetStationPointOfSales>? StationPointOfSales { get; set; }
        //public List<vw_EmployeeDetails>? StationEmployeeDetails { get; set; }
    }
}
