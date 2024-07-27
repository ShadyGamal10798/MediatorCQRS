using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Entities.Zatca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Naqleen.Presistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> modelBuilder)
        {
            modelBuilder
            .HasOne(t => t.LKOrderType)
            .WithMany(i => i.Orders)
            .HasForeignKey(t => t.OrderTypeId);

            modelBuilder
           .HasOne(t => t.LKProduct)
           .WithMany(i => i.Orders)
           .HasForeignKey(t => t.ProductId);

            modelBuilder
           .HasOne(t => t.ApplicationUser)
           .WithMany(i => i.Orders)
           .HasForeignKey(t => t.CreatedBy);

            modelBuilder
          .HasOne(t => t.Customer)
          .WithMany(i => i.Orders)
          .HasForeignKey(t => t.CustomerId)
          .IsRequired(false); // Make the foreign key optional;

            modelBuilder
         .HasOne(t => t.Station)
         .WithMany(i => i.Orders)
         .HasForeignKey(t => t.StationId);

            modelBuilder
            .HasOne(u => u.Escape)
            .WithOne(up => up.Order)
            .HasForeignKey<Escape>(u => u.OrderId);

            modelBuilder
           .HasOne(u => u.XMLData)
           .WithOne(up => up.Order)
           .HasForeignKey<XMLData>(u => u.OrderId);

            modelBuilder
         .HasOne(u => u.InvalidZatcaInvoice)
         .WithOne(up => up.Order)
         .HasForeignKey<InvalidZatcaInvoice>(u => u.OrderId);

            modelBuilder
        .HasOne(t => t.LKInvoiceType)
        .WithMany(i => i.Orders)
        .HasForeignKey(t => t.LKInvoiceTypeId);

            modelBuilder
                .HasOne(o => o.CreditOrDebitMainOrder)
                .WithMany()
                .HasForeignKey(o => o.CreditOrDepitMainOrderId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder
               .HasIndex(e => e.OrderSerial)
               .IsUnique();

            modelBuilder
                 .HasOne(o => o.PointOfSale)
                 .WithMany(p => p.Orders) 
                 .HasForeignKey(o => o.AndroidId)
                 .HasPrincipalKey(p => p.AndroidId);

            
        }
    }

}
