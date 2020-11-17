using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marmify.Infraestructure.Data.Context.Configuration.Identity
{
    // Configure Table IdentityRole
    public static class IdentityUserLoginConfig
    {
        public static void ConfigurationIdentityUserLogin(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<long>>()
                .ToTable("user_login");
            builder.Entity<IdentityUserLogin<long>>().Property(p => p.LoginProvider)
                .HasColumnName("login_provider");
            builder.Entity<IdentityUserLogin<long>>().Property(p => p.ProviderKey)
                .HasColumnName("provider_key");
            builder.Entity<IdentityUserLogin<long>>().Property(p => p.ProviderDisplayName)
                .HasColumnName("provider_display_name");
            builder.Entity<IdentityUserLogin<long>>().Property(p => p.UserId)
                .HasColumnName("user_id");
        }
    }
}
