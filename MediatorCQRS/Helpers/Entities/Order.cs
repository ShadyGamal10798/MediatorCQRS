using MediatorCQRS.Helpers.Entities.Zatca;

namespace MediatorCQRS.Helpers.Entities
{
    public class Order : BaseEntity<int>
    {
        public string? OrderSerial { get; set; }
        public int OrderTypeId { get; set; }
        public int ProductId { get; set; }
        public int StationId { get; set; }
        public decimal Liters { get; set; }
        public decimal Price { get; set; }
        public int LKInvoiceTypeId { get; set; }
        public string? AndroidId { get; set; }
        public int? CreditOrDepitMainOrderId { get; set; }
        public string? InstructionNote { get; set; }
        public int? CustomerId { get; set; }
        public string? XMLError { get; set; }
        public bool XMLStatus { get; set; }
        public bool ZatcaStatus { get; set; }
        public string? ZatcaError { get; set; }
        public string? MadaTransactionNum { get; set; }
        public bool HasCreditOrDebit { get; set; }

        public LKOrderType LKOrderType { get; set; }
        public LKProduct LKProduct { get; set; }
        public Station Station { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Customer? Customer { get; set; }
        public Escape? Escape { get; set; }
        public XMLData? XMLData { get; set; }
        public InvalidZatcaInvoice? InvalidZatcaInvoice { get; set; }
        public LKInvoiceType LKInvoiceType { get; set; }
        public Order CreditOrDebitMainOrder { get; set; }
        public PointOfSale PointOfSale { get; set; }

    }

}
