using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marmify.Infraestructure.Data.Context.Configuration.Identity
{
    // Configure Table IdentityUserRole
    public static class IdentityUserRoleConfig
    {
        public static void ConfigurationIdentityUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<long>>()
                .ToTable("user_role");
            builder.Entity<IdentityUserRole<long>>().Property(p => p.RoleId)
                .HasColumnName("role_id");
            builder.Entity<IdentityUserRole<long>>().Property(p => p.UserId)
                .HasColumnName("user_id");
        }
    }
}
