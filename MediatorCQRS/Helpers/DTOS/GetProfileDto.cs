namespace MediatorCQRS.Helpers.DTOS
{
    public record GetProfileDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string EmployeeNumber { get; set; }
        public int StationId { get; set; }
    }
}
