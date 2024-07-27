using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediatorCQRS.Helpers.Entities;

namespace Naqleen.Presistence.Configurations
{
    public class StationProductConfiguration : IEntityTypeConfiguration<StationProduct>
    {
        public void Configure(EntityTypeBuilder<StationProduct> modelBuilder)
        {
            modelBuilder
            .HasKey(sp => new { sp.StationId, sp.LKProductId });

            modelBuilder
                .HasOne(sp => sp.Station)
                .WithMany(s => s.StationProducts)
                .HasForeignKey(sp => sp.StationId);

            modelBuilder
                .HasOne(sp => sp.LKProduct)
                .WithMany(lp => lp.StationProducts)
                .HasForeignKey(sp => sp.LKProductId);
        }
    }
}
