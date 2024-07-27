using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediatorCQRS.Helpers.Entities.Zatca
{
    [Table("InvalidZatcaInvoices", Schema = "zatca")]
    public class InvalidZatcaInvoice : BaseEntity<int>
    {
        public int? OrderId { get; set; }
        public int? PostpaidInvoiceId { get; set; }
        public int? ShopRentalInvoiceId { get; set; }
        public string ResSerialized { get; set; }
        public string InvSerialized { get; set; }
        public int NumberOfRetrys { get; set; }
        public bool Status { get; set; }
        public Order? Order { get; set; }
        public PostpaidClientInvoice? PostpaidClientInvoice { get; set; }
        public ShopRentalInvoice? ShopRentalInvoice { get; set; }
    }
}
