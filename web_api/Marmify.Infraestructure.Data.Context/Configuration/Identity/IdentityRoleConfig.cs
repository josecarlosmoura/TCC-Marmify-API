using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marmify.Infraestructure.Data.Context.Configuration.Identity
{
    // Configure Table IdentityRole
    public static class IdentityRoleConfig
    {
        public static void ConfigurationIdentityRole(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<long>>()
                .ToTable("role");
            builder.Entity<IdentityRole<long>>().Property(p => p.Id)
                .HasColumnName("id");
            builder.Entity<IdentityRole<long>>().Property(p => p.ConcurrencyStamp)
                .HasColumnName("concurrency_stamp");
            builder.Entity<IdentityRole<long>>().Property(p => p.Name)
                .HasColumnName("name");
            builder.Entity<IdentityRole<long>>().Property(p => p.NormalizedName)
                .HasColumnName("normalized_mail");
        }
    }
}
