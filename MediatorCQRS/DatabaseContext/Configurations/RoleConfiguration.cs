using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Naqleen.Domain.Dictionaries;

namespace Naqleen.Presistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var roles = AllRoles.MainRoles.Select(e => new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = e.Value,
                NormalizedName = e.Value.ToUpper()
            });

            builder.HasData(roles);
        }
    }
}
