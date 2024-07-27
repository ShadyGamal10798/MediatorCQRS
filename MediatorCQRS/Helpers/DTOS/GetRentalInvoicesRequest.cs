namespace MediatorCQRS.Helpers.DTOS
{
    public class GetRentalInvoicesRequest : PaginationRequest
    {
        public string? ClientName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? StationId { get; set; }
    }

    public class GetPostpaidClientInvoicesRequest : PaginationRequest
    {
        public string? ClientName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? StationId { get; set; }
    }
}
