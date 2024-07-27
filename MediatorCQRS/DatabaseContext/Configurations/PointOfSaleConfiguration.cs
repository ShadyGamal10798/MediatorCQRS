using MediatorCQRS.Helpers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Naqleen.Presistence.Configurations
{
    public class PointOfSaleConfiguration : IEntityTypeConfiguration<PointOfSale>
    {
        public void Configure(EntityTypeBuilder<PointOfSale> modelBuilder)
        {
            modelBuilder
               .HasIndex(e => e.Ip)
               .IsUnique();

            modelBuilder
              .HasIndex(e => e.AndroidId)
              .IsUnique();

            modelBuilder
            .HasOne(pos => pos.LKPointOfSale)
            .WithMany(lkpos => lkpos.PointOfSales)
            .HasForeignKey(pos => pos.LKPointOfSaleId);
        }
    }
}
