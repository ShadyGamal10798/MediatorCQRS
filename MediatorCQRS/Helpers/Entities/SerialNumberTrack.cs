namespace MediatorCQRS.Helpers.Entities
{
    public class SerialNumberTrack
    {
        public int Id { get; set; }
        public int LastSerialNumber { get; set; }
        public int Year { get; set; }
        public int Version { get; set; }
    }
}
