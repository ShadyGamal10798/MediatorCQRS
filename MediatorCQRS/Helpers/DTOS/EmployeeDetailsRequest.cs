namespace MediatorCQRS.Helpers.DTOS
{
    public class EmployeeDetailsRequest : PaginationRequest
    {
        public string? EmployeeNumber { get; set; }

    }

    public class ClientDetailsRequest
    {
        public string? ClientName { get; set; }

    }
}
