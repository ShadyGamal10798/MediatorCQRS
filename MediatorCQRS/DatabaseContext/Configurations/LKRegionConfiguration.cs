using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediatorCQRS.Helpers.Entities;

namespace Naqleen.Presistence.Configurations
{
    public class LKRegionConfiguration : IEntityTypeConfiguration<LKRegion>
    {
        public void Configure(EntityTypeBuilder<LKRegion> modelBuilder)
        {
            modelBuilder
            .HasMany(region => region.Cities)
            .WithOne(city => city.Region)
            .HasForeignKey(city => city.LKRegionId);
        }
    }
}
