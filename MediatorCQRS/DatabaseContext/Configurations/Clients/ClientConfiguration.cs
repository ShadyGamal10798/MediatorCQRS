using MediatorCQRS.Helpers.Entities.ClientAggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Naqleen.Presistence.Configurations.Clients
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.VatNumber).IsRequired();
            builder.Property(e => e.CommercialNumber).IsRequired();
            builder.Property(e => e.Balance).IsRequired();
            builder.Property(e => e.FullAddress);
            builder.Property(e => e.CompanyName).IsRequired();


            builder
           .HasMany(c => c.ShopRentalInvoices)
           .WithOne(p => p.Client)
           .HasForeignKey(p => p.ClientId)
           .IsRequired(true);

            builder.OwnsOne(e => e.Address, ownedBuilder =>
            {
                ownedBuilder.Property(e => e.Street)
                    .HasColumnName(nameof(Address.Street))
                    .IsRequired();
                ownedBuilder.Property(e => e.BuildingNumber)
                    .HasColumnName(nameof(Address.BuildingNumber))
                    .IsRequired();
                ownedBuilder.Property(e => e.Region)
                    .HasColumnName(nameof(Address.Region))
                    .IsRequired();
                ownedBuilder.Property(e => e.City)
                    .HasColumnName(nameof(Address.City))
                    .IsRequired();
                ownedBuilder.Property(e => e.ZipCode)
                    .HasColumnName(nameof(Address.ZipCode))
                    .IsRequired();
                ownedBuilder.Property(e => e.Governorate)
                    .HasColumnName(nameof(Address.Governorate));



            });
        }
    }
}
