using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using MediatorCQRS.Helpers.Guards;

namespace MediatorCQRS.Helpers.Entities.ClientAggregateRoot
{
    public class Client : BaseEntity<int>, IActiveEntity
    {
        private string _fullAddress;
        public Client(string name, Address address, string vatNumber, string commercialNumber, string companyName, double balance = 0)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Address = Guard.Against.Null(address, nameof(address));
            VatNumber = Guard.Against.NullOrEmpty(vatNumber, nameof(vatNumber));
            CommercialNumber = Guard.Against.NullOrEmpty(commercialNumber, nameof(commercialNumber));
            CompanyName = Guard.Against.NullOrEmpty(companyName, nameof(companyName));
            Balance = balance;
            _fullAddress = Address;
        }
        private Client() { } // EF 

        public string Name { get; }
        public string CompanyName { get; }
        public double Balance { get; }
        public Address Address { get; }
        public string FullAddress => _fullAddress;
        public string VatNumber { get; }
        public string CommercialNumber { get; }

        public override string ToString() => Name;

        public ICollection<PostpaidClientInvoice>? PostpaidClientInvoices { get; set; }
        public ICollection<ShopRentalInvoice>? ShopRentalInvoices { get; set; }
    }
}
