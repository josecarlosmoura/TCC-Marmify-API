using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marmify.Infraestructure.Data.Context.Configuration.Identity
{
    // Configure Table IdentityUserClaim
    public static class IdentityUserClaimConfig
    {
        public static void ConfigurationIdentityUserClaim(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<long>>()
                .ToTable("user_claim");
            builder.Entity<IdentityUserClaim<long>>().Property(p => p.Id)
                .HasColumnName("id");
            builder.Entity<IdentityUserClaim<long>>().Property(p => p.ClaimType)
                .HasColumnName("claim_type");
            builder.Entity<IdentityUserClaim<long>>().Property(p => p.ClaimValue)
                .HasColumnName("claim_value");
            builder.Entity<IdentityUserClaim<long>>().Property(p => p.UserId)
                .HasColumnName("user_id");
        }
    }
}
