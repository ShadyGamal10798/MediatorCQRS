using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Naqleen.Presistence.Configurations.Invoice
{
    public class ShopRentalInvoiceConditionConfiguration : InvoiceConditionConfiguration<ShopRentalInvoiceCondition>
    {
        public override void Configure(EntityTypeBuilder<ShopRentalInvoiceCondition> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.SalesType).IsRequired();
        }
    }

}
