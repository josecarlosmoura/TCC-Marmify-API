using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
    public static class AddressConfig
    {
        public static void ConfigurationAddress(ModelBuilder builder)
        {
            builder.Entity<Address>().HasKey(x => x.Id);

            builder.Entity<Address>()
                .HasOne(x => x.User)
                .WithMany(x => x.Addresses)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Entity<Address>()
                .ToTable("address");

            builder.Entity<Address>().Property(x => x.Id)
                .HasColumnName("id");
            builder.Entity<Address>().Property(x => x.Street)
                .HasColumnName("street")
                .HasMaxLength(100);
            builder.Entity<Address>().Property(x => x.Number)
                .HasColumnName("number");
            builder.Entity<Address>().Property(x => x.Neighborhood)
                .HasColumnName("neighborhood")
                .HasMaxLength(50);
            builder.Entity<Address>().Property(x => x.PostalCode)
                .HasColumnName("postal_code")
                .HasMaxLength(20);
            builder.Entity<Address>().Property(x => x.UserId)
                .HasColumnName("user_id");
        }
    }
}
