using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marmify.Infraestructure.Data.Context.Configuration.Identity
{
    // Configure Table IdentityUserToken
    public static class IdentityUserTokenConfig
    {
        public static void ConfigurationIdentityUserToken(ModelBuilder builder)
        {
            builder.Entity<IdentityUserToken<long>>()
                .ToTable("user_token");
            builder.Entity<IdentityUserToken<long>>().Property(p => p.UserId)
                .HasColumnName("user_id");
            builder.Entity<IdentityUserToken<long>>().Property(p => p.LoginProvider)
                .HasColumnName("login_provider");
            builder.Entity<IdentityUserToken<long>>().Property(p => p.Name)
                .HasColumnName("name");
            builder.Entity<IdentityUserToken<long>>().Property(p => p.Value)
                .HasColumnName("value");
        }
    }
}
