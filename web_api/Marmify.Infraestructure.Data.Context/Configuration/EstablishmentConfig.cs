using Marmify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marmify.Infraestructure.Data.Context.Configuration
{
    // Configure Table Establishment
    public static class EstablishmentConfig
    {
        public static void ConfigurationEstablishment(ModelBuilder builder)
        {
            builder.Entity<Establishment>().HasKey(x => x.Id);

            builder.Entity<Establishment>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Establishment)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.Entity<Establishment>()
                .HasMany(x => x.Itens)
                .WithOne(x => x.Establishment)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Establishment>()
                .HasMany(x => x.PurchaseOrders)
                .WithOne(x => x.Establishment)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Establishment>()
                .ToTable("establishment");

            builder.Entity<Establishment>().Property(x => x.Id)
                .HasColumnName("id");
            builder.Entity<Establishment>().Property(x => x.CorporateName)
                .HasColumnName("corporate_name")
                .HasMaxLength(100);
            builder.Entity<Establishment>().Property(x => x.Cnpj)
                .HasColumnName("cnpj")
                .HasMaxLength(14);
            builder.Entity<Establishment>().Property(x => x.CompanyName)
                .HasColumnName("company_name")
                .HasMaxLength(100);
            builder.Entity<Establishment>().Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(100);
            builder.Entity<Establishment>().Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20);
            builder.Entity<Establishment>().Property(x => x.Address)
                .HasColumnName("address")
                .HasMaxLength(100);
            builder.Entity<Establishment>().Property(x => x.Number)
                .HasColumnName("number");
            builder.Entity<Establishment>().Property(x => x.Neighborhood)
                .HasColumnName("neighborhood")
                .HasMaxLength(100);
            builder.Entity<Establishment>().Property(x => x.IsPartner)
                .HasColumnName("is_partner");

        }
    }
}
