namespace MediatorCQRS.Helpers.DTOS
{
    public class UpdateEmployeeDetailsRequest
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Job { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public string? Email { get; set; }

    }
    public class UpdateEmployeeDetailsResponse
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? Job { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public string? Email { get; set; }
    }
}
