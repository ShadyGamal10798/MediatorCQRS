using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using MediatorCQRS.Helpers.Entities.Zatca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Naqleen.Presistence.Configurations.Invoice
{
    public class PostpaidClientInvoiceConfiguration : InvoiceConfiguration<PostpaidClientInvoice, PostpaidClientInvoiceCondition>
    {
        public override void Configure(EntityTypeBuilder<PostpaidClientInvoice> builder)
        {
            base.Configure(builder);

            builder.HasMany(e => e.Conditions)
                .WithOne()
                .HasForeignKey(e => e.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.AdminApplicationUser)
                .WithMany(i => i.AdminPostpaidClientInvoices)
                .HasForeignKey(t => t.CreatedBy)
            .IsRequired();

            builder
      .HasOne(t => t.Client)
      .WithMany(i => i.PostpaidClientInvoices)
      .HasForeignKey(t => t.ClientId)
      .IsRequired(true);

            builder
          .HasOne(u => u.XMLData)
          .WithOne(up => up.PostpaidClientInvoice)
          .HasForeignKey<XMLData>(u => u.PostpaidInvoiceId);

            builder
        .HasOne(u => u.InvalidZatcaInvoice)
        .WithOne(up => up.PostpaidClientInvoice)
        .HasForeignKey<InvalidZatcaInvoice>(u => u.PostpaidInvoiceId);

            builder
       .HasOne(t => t.LKInvoiceType)
      .WithMany(i => i.PostpaidClientInvoices)
      .HasForeignKey(t => t.LKInvoiceTypeId);
        }
    }
}
