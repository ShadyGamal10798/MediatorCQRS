using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediatorCQRS.Helpers.Entities;

namespace Naqleen.Presistence.Configurations
{
    public class TankConfiguration : IEntityTypeConfiguration<Tank>
    {
        public void Configure(EntityTypeBuilder<Tank> modelBuilder)
        {
            modelBuilder
            .HasOne(t => t.LKProduct)
            .WithMany(p => p.Tanks)
            .HasForeignKey(t => t.LKProductId);
        }
    }
}
