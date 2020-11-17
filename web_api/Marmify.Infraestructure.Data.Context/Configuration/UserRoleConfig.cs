using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
    public static class UserRoleConfig
    {
        public static void ConfigurationUserRole(ModelBuilder builder)
        {
            builder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<UserRole>()
                .ToTable("user_role");

            builder.Entity<UserRole>().Property(p => p.RoleId)
                .HasColumnName("role_id");
            builder.Entity<UserRole>().Property(p => p.UserId)
                .HasColumnName("user_id");
        }
    }
}
