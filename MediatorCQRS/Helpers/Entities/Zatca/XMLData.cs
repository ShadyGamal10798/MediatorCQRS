using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatorCQRS.Helpers.Entities.Zatca
{
    [Table("XMLsData", Schema = "zatca")]
    public class XMLData : BaseEntity<int>
    {
        public int? OrderId { get; set; }
        public int? PostpaidInvoiceId { get; set; }
        public int? ShopRentalInvoiceId { get; set; }

        public int InvoiceCounter { get; set; }
        public string UUID { get; set; }
        public string EncodedInvoice { get; set; }
        public string InvoiceHash { get; set; }
        public string QrCode { get; set; }
        public bool ZatcaStatus { get; set; }
        public string? ReportingStatus { get; set; }
        public string? ClearanceStatus { get; set; }
        public string? ErrorMessage { get; set; }
        public string? WarningMessage { get; set; }
        public string? ClearedInvoice { get; set; }
        public int StatusCode { get; set; }
        public string SingedXMLFileNameFullPath { get; set; }
        public string NormalXMLFileNameFullPath { get; set; }
        public string? ClearedXMLFileNameFullPath { get; set; }
        public Order? Order { get; set; }
        public PostpaidClientInvoice? PostpaidClientInvoice { get; set; }
        public ShopRentalInvoice? ShopRentalInvoice { get; set; }
    }
}
