namespace MediatorCQRS.Helpers.DTOS
{
    public class CustomerDetailsRequest : PaginationRequest
    {
        public string? CustomerName { get; set; }
    }
}
