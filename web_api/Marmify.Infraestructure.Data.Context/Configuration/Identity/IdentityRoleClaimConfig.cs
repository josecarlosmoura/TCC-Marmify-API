using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marmify.Infraestructure.Data.Context.Configuration.Identity
{
    // Configure Table IdentityRoleClaim
    public static class IdentityRoleClaimConfig
    {
        public static void ConfigurationIdentityRoleClaim(ModelBuilder builder)
        {
            builder.Entity<IdentityRoleClaim<long>>()
                .ToTable("role_claim");
            builder.Entity<IdentityRoleClaim<long>>().Property(p => p.Id)
                .HasColumnName("id");
            builder.Entity<IdentityRoleClaim<long>>().Property(p => p.ClaimType)
                .HasColumnName("claim_type");
            builder.Entity<IdentityRoleClaim<long>>().Property(p => p.ClaimValue)
                .HasColumnName("claim_value");
            builder.Entity<IdentityRoleClaim<long>>().Property(p => p.RoleId)
                .HasColumnName("role_id");
        }
    }
}
