namespace MediatorCQRS.Helpers.DTOS.Views
{
    public class vw_GetStationPumps
    {
        public int PumpId { get; set; }
        public int StationId { get; set; }
        public string PumpCode { get; set; }
        public string ERPCodePump { get; set; }
        public string StationName { get; set; }
        public int TankId { get; set; }
        public string TankCode { get; set; }
    }
}
