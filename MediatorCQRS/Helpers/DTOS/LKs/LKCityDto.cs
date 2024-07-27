namespace MediatorCQRS.Helpers.DTOS.LKs
{
    public class LKCityDto
    {
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
    }
    public class vw_GetCityByRegionId
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int RegionId { get; set; }
    }
}
