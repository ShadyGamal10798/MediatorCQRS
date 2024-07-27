using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediatorCQRS.Helpers.Entities;

namespace Naqleen.Presistence.Configurations
{
    public class PumpConfiguration : IEntityTypeConfiguration<Pump>
    {
        public void Configure(EntityTypeBuilder<Pump> modelBuilder)
        {
            modelBuilder
            .HasOne(p => p.Tank)
            .WithMany(t => t.Pumps)
            .HasForeignKey(p => p.TankId);
        }
    }
}
