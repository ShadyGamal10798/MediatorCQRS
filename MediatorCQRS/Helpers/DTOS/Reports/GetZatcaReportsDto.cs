namespace MediatorCQRS.Helpers.DTOS.Reports
{
    public class GetZatcaReportsDto
    {
        public int Id { get; set; }
        public string OrderSerial { get; set; }
        public string StationName { get; set; }
        public string City { get; set; }
        public string ProductName { get; set; }
        public decimal Liters { get; set; }
        public decimal Price { get; set; }
        public string WorkerNumber { get; set; }
        public string InvoiceType { get; set; }
        public string PaymentType { get; set; }
        public string? CreditOrDebitOrderSerial { get; set; }
        public bool CreditOrDebitStatus { get; set; }
        public bool HasCreditOrDebit { get; set; }
        public string ZatcaStatus { get; set; }
        public bool IsActive { get; set; }
        public int StationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OrderTypeId { get; set; }
        public int ProductId { get; set; }
        public bool BoolZatcaStatus { get; set; }


    }
}
