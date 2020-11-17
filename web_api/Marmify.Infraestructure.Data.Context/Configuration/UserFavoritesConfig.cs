using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
    // Configure Table UserFavorites
    public static class UserFavoritesConfig
    {
        public static void ConfigurationUserFavorites(ModelBuilder builder)
        {
            builder.Entity<UserFavorites>().HasKey(x => x.Id);

            builder.Entity<UserFavorites>()
                .ToTable("user_favorites");

            builder.Entity<UserFavorites>().Property(x => x.Id)
                .HasColumnName("id");
            builder.Entity<UserFavorites>().Property(x => x.UserId)
                .HasColumnName("user_id");
            builder.Entity<UserFavorites>().Property(x => x.EstablishmentId)
                .HasColumnName("establishment_id");
        }
    }
}
