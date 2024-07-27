using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using MediatorCQRS.Helpers.Entities.Zatca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Naqleen.Presistence.Configurations.Invoice
{

    public class ShopRentalInvoiceConfiguration : InvoiceConfiguration<ShopRentalInvoice, ShopRentalInvoiceCondition>
    {
        public override void Configure(EntityTypeBuilder<ShopRentalInvoice> builder)
        {
            base.Configure(builder);

            builder.HasMany(e => e.Conditions)
                .WithOne()
                .HasForeignKey(e => e.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.AdminApplicationUser)
                .WithMany(i => i.AdminShopRentalInvoices)
                .HasForeignKey(t => t.CreatedBy)
                .IsRequired();



            builder
          .HasOne(u => u.XMLData)
          .WithOne(up => up.ShopRentalInvoice)
          .HasForeignKey<XMLData>(u => u.ShopRentalInvoiceId);

            builder
        .HasOne(u => u.InvalidZatcaInvoice)
        .WithOne(up => up.ShopRentalInvoice)
        .HasForeignKey<InvalidZatcaInvoice>(u => u.ShopRentalInvoiceId);

            builder
       .HasOne(t => t.LKInvoiceType)
      .WithMany(i => i.ShopRentalInvoices)
      .HasForeignKey(t => t.LKInvoiceTypeId);
        }
    }
}
