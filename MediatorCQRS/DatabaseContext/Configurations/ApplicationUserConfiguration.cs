using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MediatorCQRS.Helpers.Entities;

namespace Naqleen.Presistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> modelBuilder)
        {
            modelBuilder
              .HasIndex(u => u.EmployeeNumber)
              .IsUnique();

            modelBuilder.Property(u => u.PasswordNeedToReset).HasDefaultValue(false);

            modelBuilder.Property(e => e.OTP)
                .HasMaxLength(6)  // Set the maximum length to 8
                .IsRequired(false);  // Make the property nullable
        }
    }
}
