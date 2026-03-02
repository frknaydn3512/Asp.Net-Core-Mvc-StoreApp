using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                // IMPORTANT: IdentityRole default ctor generates Id/ConcurrencyStamp via Guid.NewGuid().
                // If we don't hardcode these, EF Core model becomes non-deterministic and migrations validation fails.
                // Values below are aligned with existing migration: 20260227090103_IdentityRoleSeedData.
                new IdentityRole()
                {
                    Id = "2e748983-61fd-4172-9d00-b6e947e951a6",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "191a5ec5-88a1-4bf5-8b5f-ee6320dbef61"
                },
                new IdentityRole()
                {
                    Id = "0d1da3cd-0386-499c-812d-214314562d80",
                    Name = "Editor",
                    NormalizedName = "EDITOR",
                    ConcurrencyStamp = "2cdab84c-2b6a-4791-9530-da4e757fccc6"
                },
                new IdentityRole()
                {
                    Id = "1c57c0a5-d95a-4845-9a4f-10e939af7bbd",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "c7c8b5f8-0c52-4afd-908f-6abaffe5ad92"
                }
            );
        }
    }
}