using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Naqleen.Presistence.Configurations.Invoice
{
    public class InvoiceConfiguration<T, TCondition> : IEntityTypeConfiguration<T>
        where T : Invoice<TCondition>
        where TCondition : InvoiceCondition
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PaymentMethod).IsRequired();
            builder.Property(e => e.TotalPrice).IsRequired().HasPrecision(15, 3);
            builder.Property(e => e.LiteralTotalPrice).IsRequired();
            builder.Property(e => e.InvoiceDate).IsRequired();

            builder.Property(e => e.TotalPriceAfterDiscount).IsRequired().HasPrecision(12, 3);
            builder.Property(e => e.TotalTax).IsRequired().HasPrecision(10, 3);
            builder.Property(e => e.FinalPrice).IsRequired().HasPrecision(15, 3);

            builder.HasOne(e => e.Station)
                .WithMany()
                .HasForeignKey(e => e.StationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Client)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(e => e.Discount, e =>
            {
                e.Property(e => e.Value)
                    .HasColumnName("DiscountValue")
                    .IsRequired()
                    .HasPrecision(15, 5);
                e.Property(e => e.Type)
                    .HasColumnName("DiscountType")
                    .HasDefaultValue(DiscountType.Value);
            });

         //   builder
         //.HasOne(u => u.CreditOrDepitMainOrderId)
         //.WithOne(up => up.Order)
         //.HasForeignKey<InvalidZatcaInvoice>(u => u.OrderId);


        }
    }
}
