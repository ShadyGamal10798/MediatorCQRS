namespace MediatorCQRS.Helpers.DTOS.Zatca
{
    public class SearchOrdersDto
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? OrderSerial { get; set; }
        public string? EmployeeNumber { get; set; }
        public int? StationId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? ZatcaStatus { get; set; }
        public int? OrderTypeId { get; set; }
        public decimal? Price { get; set; }
        public int? ProductId { get; set; }
    }
}
