namespace MediatorCQRS.Helpers.DTOS
{
    public class SendOrderDetailsDto
    {
        public int? OrderId { get; set; }
        public int OrderTypeId { get; set; }
        public int ProductId { get; set; }
        public int? StationId { get; set; }
        public decimal Liters { get; set; }
        public decimal Price { get; set; }
        public string? CreatedBy { get; set; }
        //public DateTime? CreatedDate { get; set; }
        public string? InvoiceType { get; set; }
        public string? MadaTransactionNum { get; set; }
        public int? CustomerId { get; set; }
        public EscapeDto? EscapeDto { get; set; }
        public DateTime? PreviousOrderIssuedDate { get; set; }
        public string? PreviousOrderSerial { get; set; }
        public string? InstructionNote { get; set; }
        public string AndroidId { get; set; }

    }
}
