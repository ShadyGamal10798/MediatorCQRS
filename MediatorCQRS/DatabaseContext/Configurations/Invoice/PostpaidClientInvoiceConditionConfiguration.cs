using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Naqleen.Presistence.Configurations.Invoice
{
    public class PostpaidClientInvoiceConditionConfiguration : InvoiceConditionConfiguration<PostpaidClientInvoiceCondition>
    {
        public override void Configure(EntityTypeBuilder<PostpaidClientInvoiceCondition> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
