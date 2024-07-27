using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediatorCQRS.Helpers.Entities;

namespace Naqleen.Presistence.Configurations
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> modelBuilder)
        {
             modelBuilder
            .HasMany(a => a.Tanks)
            .WithOne(u => u.Station)
            .HasForeignKey(a => a.StationId)
            .IsRequired();

            modelBuilder
            .HasMany(a => a.Pumps)
            .WithOne(u => u.Station)
            .HasForeignKey(a => a.StationId)
            .IsRequired();

            modelBuilder
            .HasOne(a => a.LKCity)
            .WithMany(u => u.Station)
            .HasForeignKey(a => a.CityId)
            .IsRequired();

            modelBuilder
           .HasOne(a => a.LKRegion)
           .WithMany(u => u.Station)
           .HasForeignKey(a => a.RegionId)
           .IsRequired();

            modelBuilder
            .HasMany(s => s.PointOfSales)
            .WithOne(p => p.Station)
            .HasForeignKey(p => p.StationId);

        }
    }
}
