using MediatorCQRS.Helpers.Guards;

namespace MediatorCQRS.Helpers.Entities.ClientAggregateRoot
{
    public class Address
    {
        public Address(string street, string buildingNumber, string region, string city, string zipCode, string governorate = "")
        {
            Street = Guard.Against.NullOrEmpty(street, nameof(street));
            BuildingNumber = Guard.Against.NullOrEmpty(buildingNumber, nameof(buildingNumber));
            Region = Guard.Against.NullOrEmpty(region, nameof(region));
            City = Guard.Against.NullOrEmpty(city, nameof(city));
            ZipCode = Guard.Against.NullOrEmpty(zipCode, nameof(zipCode));
            Governorate = governorate;
        }
        private Address() { } //EF

        public string Street { get; }
        public string BuildingNumber { get; }
        public string City { get; }
        public string ZipCode { get; }
        public string Governorate { get; }
        public string Region { get; }

        public override string ToString() => $"{BuildingNumber} {Street} {Region} {City} {Governorate}".Trim();

        public static implicit operator string(Address address) => address.ToString();
    }
}
