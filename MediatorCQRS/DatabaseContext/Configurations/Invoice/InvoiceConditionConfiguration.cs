using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Naqleen.Presistence.Configurations.Invoice
{
    public class InvoiceConditionConfiguration<T> : IEntityTypeConfiguration<T>
        where T : InvoiceCondition
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TaxType).HasMaxLength(3).IsRequired();
            builder.Property(e => e.TaxRate).IsRequired();
            builder.Property(e => e.Amount).IsRequired().HasPrecision(10, 3);
            builder.Property(e => e.UnitPrice).IsRequired().HasPrecision(10, 3);
            builder.Property(e => e.TotalPrice).IsRequired().HasPrecision(15, 3);
            builder.Property(e => e.TaxValue).IsRequired().HasPrecision(10, 3);
            
            builder.Ignore(e => e.TotalPriceWithoutTax);
        }
    }

}
