using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediatorCQRS.Helpers.Entities;

namespace Naqleen.Presistence.Configurations
{
    public class MainPriceHistoryConfiguration : IEntityTypeConfiguration<MainPriceHistory>
    {
        public void Configure(EntityTypeBuilder<MainPriceHistory> modelBuilder)
        {
            modelBuilder
            .HasOne(lkp => lkp.LKProduct)
            .WithMany()
            .HasForeignKey(lkp => lkp.LKProductId);
        }
    }
}
