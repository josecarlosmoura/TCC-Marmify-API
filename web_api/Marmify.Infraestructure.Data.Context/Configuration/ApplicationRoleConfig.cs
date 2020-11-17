using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
    public static class ApplicationRoleConfig
    {
        public static void ConfigurationApplicationRole(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>()
                    .ToTable("role");

            builder.Entity<ApplicationRole>().Property(p => p.Id)
                    .HasColumnName("id");
            builder.Entity<ApplicationRole>().Property(p => p.ConcurrencyStamp)
                    .HasColumnName("concurrency_stamp");
            builder.Entity<ApplicationRole>().Property(p => p.Name)
                    .HasColumnName("name");
            builder.Entity<ApplicationRole>().Property(p => p.NormalizedName)
                    .HasColumnName("normalized_mail");
        }
    }
}
