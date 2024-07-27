using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

namespace MediatorCQRS.Helpers.Entities
{
    public class LKInvoiceType
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<PostpaidClientInvoice>? PostpaidClientInvoices { get; set; }
        public ICollection<ShopRentalInvoice>? ShopRentalInvoices { get; set; }

    }
}
